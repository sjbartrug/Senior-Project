using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AiStateID
{
    ChasePlayer,
    Wander
}
public interface AIState
{
    AiStateID GetID();
    void Enter(GnomeyAI agent);
    void Update(GnomeyAI agent);
    void Exit(GnomeyAI agent);
}
