using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour, IUpdateable
{
    //private Dictionary<EnemyStatesEnum, GameState> enemyStateMap;

    private EnemyState currentState;
    private EnemyState previousState;

    private void Start()
    {
        //set current state
    }

    public void ChangeState(EnemyState newState)
    {
        //EnemyState newState = gameStateMap[newStateEnum];

        if (currentState != null)
            currentState.Exit();
        previousState = currentState;
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateState()
    {
        currentState?.UpdateState();
        Debug.Log("enemy");
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
