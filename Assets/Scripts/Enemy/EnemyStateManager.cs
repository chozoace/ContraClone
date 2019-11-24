using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStateManager : MonoBehaviour, IUpdateable
{
    protected Dictionary<string, EnemyState> enemyStateMap = new Dictionary<string, EnemyState>();

    protected EnemyState currentState;
    protected EnemyState previousState;

    public FloatReference playerHp;

    [SerializeField]
    protected WorldGrid worldGrid;
    public WorldGrid WorldGrid { get { return worldGrid; } }

    public void ChangeState(string newStateEnum)
    {
        EnemyState newState = enemyStateMap[newStateEnum.ToString()];

        if (currentState != null)
            currentState.Exit();
        previousState = currentState;
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateState()
    {
        currentState?.UpdateState();
    }

    public void FixedUpdateState()
    {
        currentState?.FixedUpdateState();
    }

    void IUpdateable.UpdateSelf()
    {
        UpdateState();
    }

    void IUpdateable.FixedUpdateSelf()
    {
        FixedUpdateState();
    }
}