using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface EventListener
{
    void ProcessEvent(ProtAction ev);
}

public class EventManager : MonoBehaviour {

    #region Unity Properties
    public bool ManualUpdate;
    #endregion

    public static EventManager CurrentEventManager;
    public string CurrentScene;
    
    private List<ProtAction> actions = new List<ProtAction>();
    private List<ProtTrigger> triggers = new List<ProtTrigger>();

    private List<string> actorsBlocked = new List<string>();
    ProtAction currentAction;
    bool blocked = false;

    

    public void OnZoneEnter(GameObject obj, int zoneIndex)
    {
        Debug.Log("OnZoneEnter!");
        var we = obj.GetComponent<WorldElementBehaviour>();
        if (we == null)
        {
            Debug.Log("No se encontró CharacterBehaviour en el objeto " + obj.name);
            return;
        }
                
        foreach (var t in triggers.ToArray())
        {
            var zoneTrigger = t as ZoneEnterTrigger;
            if (zoneTrigger == null || !zoneTrigger.CheckZoneCondition(we.ActorName, zoneIndex))
                continue;
            var ok = true;
            foreach (var condition in zoneTrigger.Conditions)
                if (!condition.CheckCondition())
                {
                    ok = false;
                    break;
                }
            if (ok)
            {
                Debug.Log("Acciones del trigger encoladas");
                actions.AddRange(t.Actions);
                if (t.OneTime)
                    triggers.Remove(t);
            }
        }
    }

    public void EnqueueAction(ProtAction ev)
    {
        Debug.Log("Encolado evento " + ev.ToString());
        actions.Add(ev);
    }

    void Start () {
        CurrentScene = SceneManager.GetActiveScene().name;
        CurrentEventManager = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            var s = "";
            foreach (var action in actions)
                s += "Action : " + action.ActionType + "\n";
            Debug.Log(s);
        }

        if (ManualUpdate)
        {
            if (Input.GetKeyDown(KeyCode.G))
                ProcessActions();
        }
        else
            ProcessActions();
        
	}

    private void ProcessActions()
    {
        if (actions.Count <= 0 || blocked)
            return;

        currentAction = null;
        foreach(var action in actions)
        {
            if (!actorsBlocked.Contains(action.ActorName))
            {
                currentAction = action;
                break;
            }
        }

        if (currentAction == null)
            return;

        Debug.Log("Procesando acción " + currentAction.ActionType);
        actions.Remove(currentAction);

        blocked = currentAction.Blocker;
        if (currentAction.ActorBlocker)
            actorsBlocked.Add(currentAction.ActorName);
        
        switch (currentAction.ActionType)
        {
            case eCmdType.DialogLine:
                ProcessAction(currentAction as DialogLineAction);
                break;
            case eCmdType.SetCinematicState:
                ProcessAction(currentAction as SetCinematicStateAction);
                break;
            case eCmdType.MoveCharacter:
                ProcessAction(currentAction as MoveCharacterAction);
                break;
            case eCmdType.LoadScene:
                ProcessAction(currentAction as LoadSceneAction);
                break;
            case eCmdType.WaitTime:
                ProcessAction(currentAction as WaitTimeAction);
                break;
        }
    }

    #region ProcessAction(s)
    #region SetCinematicState
    private void ProcessAction(SetCinematicStateAction action)
    {
        GlobalConfig.CharControlEnabled = !action.StateValue;
        ProcessActionCallback(action);
    }
    #endregion

    #region WaitSeconds
    private void ProcessAction(WaitTimeAction action)
    {
        action.Wait(ProcessActionCallback);
    }
    #endregion

    #region SceneLoad
    Scene currentScene;
    LoadSceneAction sceneAction;
    List<GameObject> toMove = new List<GameObject>();
    private void ProcessAction(LoadSceneAction action)
    {
        currentScene = SceneManager.GetActiveScene();
        toMove.Clear();

        var eventSystem = GameObject.Find("EventSystem");
        if (eventSystem != null)
            toMove.Add(eventSystem);

        InterestPointBehaviour.OnSceneLoading();
        sceneAction = action;
        SceneManager.LoadScene(action.SceneIndex, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Carga completa -- Escena " + scene.name);

        foreach (var go in toMove)
            SceneManager.MoveGameObjectToScene(go, scene);

        // Unload the previous Scene
        SceneManager.UnloadScene(currentScene);
        GlobalConfig.MainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        //Cargar scripts de la escena
        LoadScene1Scripts();

        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;

        ProcessActionCallback(sceneAction);
        sceneAction = null;
    }

    private void LoadScene1Scripts()
    {
        Debug.Log("Creando Scripts para la escena 1");
        //Movimiento absurdo al bajar las escaleras
        
        triggers.Add(new ZoneEnterTrigger("Actor1", 1)
        {
            Actions = new List<ProtAction>
            {
                new SetCinematicStateAction(true),
                new DialogLineAction("Comienza!")
                {
                    ActorName = "Actor1",
                },
                new MoveCharacterAction()
                {
                    ActorName = "Actor1",
                    Destination = new Vector3(-13.68f, 20.96f, -34.26f),
                    DisableMovement = true,
                    ActorBlocker = true,
                },
                new DialogLineAction("Me pregunto qué será de mi en el futuro")
                {
                    ActorName = "Actor1",
                    ActorBlocker = true,
                },
                new WaitTimeAction(5000)
                {
                    ActorName = "Actor1",
                    ActorBlocker = true,
                },
                new DialogLineAction("Nada bueno")
                {
                    ActorName = "Actor2",
                    ActorBlocker = true,
                },
                new WaitTimeAction(5000)
                {
                    ActorName = "Actor2",
                    ActorBlocker = true,
                },
                new DialogLineAction("Nada bueno...")
                {
                    ActorName = "Actor2",
                    ActorBlocker = true,
                },
                new SetCinematicStateAction(false)
            }
        });
        
        actions.AddRange(new [] 
        {
            new MoveCharacterAction()
            {
                Destination = InterestPointBehaviour.ScenePoints["Actor2_Patrol_1"].Position,
                DisableMovement = true,
                ActorBlocker = true,
                ActorName = "Actor2",
                Repeat = true,
            },
            new MoveCharacterAction()
            {
                Destination = InterestPointBehaviour.ScenePoints["Actor2_Patrol_2"].Position,
                DisableMovement = true,
                ActorBlocker = true,
                ActorName = "Actor2",
                Repeat = true,
            }
        });
    }
    #endregion

    #region DialogLine
    private void ProcessAction(DialogLineAction ev)
    {
        Debug.Log("<-------------------->'" + ev.ActorName + "': " +  ev.Text);
    }
    #endregion

    #region MoveCharacater
    private void ProcessAction(MoveCharacterAction cmd)
    {
        Debug.Log("Moviendo actor '" + cmd.ActorName + "' al punto " + cmd.Destination);
        cmd.Actor = GameObject.Find(cmd.ActorName);
        var nav = cmd.Actor.GetComponent<NavigationManager>();
        if (nav != null)
            nav.Disabled = cmd.DisableMovement;
        cmd.Actor.GetComponent<SimpleAgentScript>().MoveCommand(cmd, ProcessActionCallback);
    }
    #endregion

    private void ProcessActionCallback(ProtAction action)
    {
        Debug.Log("Callback de acción " + action.ActionType);
        action.OnActionProcessed();

        if (actorsBlocked.Contains(action.ActorName))
            actorsBlocked.Remove(action.ActorName);

        if (action.Repeat)
            EnqueueAction(action);
        else
            action.Finished = true;

        if (action.Blocker)
            blocked = false;
    }
    #endregion
}









