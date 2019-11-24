
using UnityEngine;
using System.Collections;

public abstract class GameState : ScriptableObject
{
    [SerializeField]
    protected InputHandler inputHandler;
    [SerializeField]
    protected WorldGrid worldGrid;

    protected string stateName;
    public virtual string StateName { get { return stateName; } }
    public abstract void ClearReferences();

    //could make these into an interface for different types of states
    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
}