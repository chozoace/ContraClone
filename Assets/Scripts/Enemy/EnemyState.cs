using UnityEngine;
using System.Collections;

public abstract class EnemyState 
{
    protected string stateName;
    protected EnemyStateManager stateManager;
    public virtual string StateName { get { return stateName; } }

    protected EnemyState(EnemyStateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    //could make these into an interface for different types of states
    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
}

