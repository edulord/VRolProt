using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProtCondition
{
    public abstract bool CheckCondition();
}

public class JustOneTimeCondition : ProtCondition
{
    bool first = true;

    public override bool CheckCondition()
    {
        if (first)
        {
            first = false;
            return true;
        }
        return false;

    }
}
