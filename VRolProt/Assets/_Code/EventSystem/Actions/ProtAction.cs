using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eCmdType
{
    DialogLine, Walk,
    SetCinematicState,
    MoveCharacter,
    WaitTime,
    LoadScene
}

public abstract class ProtAction
{
    /// <summary>
    /// Indica si mientras se procesa este evento, se paraliza el procesado de toda la cola de eventos.
    /// </summary>
    public bool Blocker { get; set; }

    /// <summary>
    /// Indica si mientras se procesa este evento, se paralizan los eventos efectuados por el mismo actor.
    /// </summary>
    public bool ActorBlocker = false;

    public abstract eCmdType ActionType { get; }
    public bool Finished { get; internal set; }

    public GameObject Actor;

    public string ActorName { get; internal set; }

    public bool Repeat = false;

    public virtual void OnActionProcessed()
    {
        
    }
}

public class MoveCharacterAction : ProtAction
{
    public override eCmdType ActionType { get { return eCmdType.MoveCharacter; } }

    public Vector3 Destination;
    public float SpeedRatio;
    public bool DisableMovement;

    public override void OnActionProcessed()
    {
        var nav = Actor.GetComponent<NavigationManager>();
        if (nav != null)
            nav.Disabled = false;
    }
}

public class DialogLineAction : ProtAction
{
    public override eCmdType ActionType { get { return eCmdType.DialogLine; } }
    public string Text { get; internal set; }

    public DialogLineAction(string text)
    {
        Text = text;
    }
}

public class SetCinematicStateAction : ProtAction
{
    public override eCmdType ActionType { get { return eCmdType.SetCinematicState; } }

    public bool StateValue;

    public SetCinematicStateAction(bool stateValue)
    {
        StateValue = stateValue;
    }
}

public class LoadSceneAction : ProtAction
{
    public override eCmdType ActionType { get { return eCmdType.LoadScene; } }

    public int SceneIndex { get; internal set; }

    public LoadSceneAction(int sceneIndex)
    {
        Blocker = true;
        SceneIndex = sceneIndex;
    }
}

public class WaitTimeAction : ProtAction
{
    public override eCmdType ActionType { get { return eCmdType.WaitTime; } }

    public float Seconds { get; set; }
    
    public WaitTimeAction(int miliseconds)
    {
        Blocker = true;
        Seconds = miliseconds/1000f;
    }

    public IEnumerator Wait(Action<ProtAction> callback)
    {
        yield return new WaitForSeconds(Seconds);
        callback(this);
    }
}
