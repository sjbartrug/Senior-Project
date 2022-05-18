using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWander : AIState
{
    int current = 0;
    
    public AiStateID GetID()
    {
        return AiStateID.Wander;
    }
    public void Enter(GnomeyAI agent)
    {
        agent.navMeshAgent.destination = agent.waypoints[0].transform.position;
    }
    public void Update(GnomeyAI agent)
    {

        if(agent.sensor.Objects.Count > 0)
        {
            agent.navMeshAgent.speed = 5;
            agent.animator.SetInteger("Current State", 3);
            agent.stateMachine.ChangeState(AiStateID.ChasePlayer);
        }
        if(!agent.navMeshAgent.pathPending && agent.navMeshAgent.remainingDistance < agent.closeEnough)
        {
            current = Random.Range(0, agent.waypoints.Length);
            agent.navMeshAgent.destination = agent.waypoints[current].transform.position;
        }
    }
    public void Exit(GnomeyAI agent)
    {
        
    }
}
