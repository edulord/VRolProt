using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgentScript : MonoBehaviour {

    // Use this for initialization
    NavMeshAgent agent;
    
    private Animator animator;
    private Action<ProtAction> callback;

    private ProtAction currentCmd;

    void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        var running = true;
        if (agent.remainingDistance <= 0.01f)// || agent.isPathStale)
        {
            running = false;
            if (callback != null)
            {
                callback(currentCmd);
                currentCmd = null;
                callback = null;
            }
        }

        if (animator!=null)
            animator.SetBool("IsRun", running);
    }

    public void MoveCommand(Vector3 destination)
    {
        agent.destination = destination;
        if (animator!=null)
            animator.SetBool("IsRun", Vector3.Distance(transform.position, destination) > 0.01f);
    }

    public void MoveCommand(MoveCharacterAction cmd, Action<ProtAction> callBack)
    {
        agent.destination = cmd.Destination;
        currentCmd = cmd;
        if (animator != null)
            animator.SetBool("IsRun", Vector3.Distance(transform.position, cmd.Destination) > 0.01f);

        callback = callBack;
    }


}
