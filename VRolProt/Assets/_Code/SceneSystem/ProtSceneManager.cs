using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtSceneManager : EventListener
{
    public void ProcessEvent(ProtAction ev)
    {
        if (ev.ActionType == eCmdType.SetCinematicState)
            ProcessEvent(ev as LoadSceneAction);
    }

    void ProcessEvent(LoadSceneAction ev)
    {

    }
}
