using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChase : AIState
{
    public Transform playerTransform;
    float maxTime = 10;
    float timer;
    public AiStateID GetID()
    {
        return AiStateID.ChasePlayer;
    }

    public void Enter(GnomeyAI agent)
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        timer = maxTime;
    }

    public void Update(GnomeyAI agent)
    {
        if (!agent.enabled)
        {
            return;
        }
        if (agent.sensor.Objects.Count == 0)
        {
            timer -= Time.deltaTime;
            Debug.Log("the timer is at " + timer + " seconds");
            if (timer < 0.0f)
            {
                agent.navMeshAgent.speed = 3;
                agent.animator.SetInteger("Current State", 2);
                agent.stateMachine.ChangeState(AiStateID.Wander);
            }
        }
        if (agent.sensor.Objects.Count > 0)
        {
            timer = maxTime;
        }
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = playerTransform.position;
        }
        Vector3 direction = (playerTransform.position - agent.navMeshAgent.destination);
        direction.y = 0;
        if(direction.sqrMagnitude > agent.agentConfig.maxDistance * agent.agentConfig.maxDistance)
        {
            if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
            {
               agent.navMeshAgent.destination = playerTransform.position;
            }
        }
    }

    public void Exit(GnomeyAI agent)
    {
        agent.navMeshAgent.speed = 3;
        agent.animator.SetInteger("Current State", 2);
    }
  
}
