using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GnomeyAI : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AiStateID initialState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig agentConfig;
    public GameObject[] waypoints;
    public float closeEnough = 0.5f;
    public AISensor sensor;
    public Animator animator;
     

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        sensor = GetComponent<AISensor>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterStates(new AIChase());
        stateMachine.RegisterStates(new AIWander());
        stateMachine.ChangeState(initialState);
        animator.SetInteger("Current State", 2);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
