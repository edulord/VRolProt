using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProtTrigger
{
    public List<ProtCondition> Conditions = new List<ProtCondition>();
    public List<ProtAction> Actions = new List<ProtAction>();
    public List<ProtTrigger> Triggers = new List<ProtTrigger>();

    public bool OneTime { get; internal set; }

    public bool CheckConditions()
    {
        foreach (var condition in Conditions)
            if (!condition.CheckCondition())
                return false;
        return true;
    }
}

public class ZoneEnterTrigger : ProtTrigger
{
    public string ActorName;
    public int ZoneIndex;

    public ZoneEnterTrigger(string actor, int zoneIndex)
    {
        ActorName = actor;
        ZoneIndex = zoneIndex;
    }
    
    public bool CheckZoneCondition(string actor, int zoneIndex)
    {
        return ActorName == actor && ZoneIndex == zoneIndex;
    }
}
