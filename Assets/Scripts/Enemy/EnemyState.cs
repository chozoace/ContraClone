using UnityEngine;
using System.Collections;

public abstract class EnemyState 
{
    protected string stateName;
    public virtual string StateName { get { return stateName; } }

    //could make these into an interface for different types of states
    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
}

