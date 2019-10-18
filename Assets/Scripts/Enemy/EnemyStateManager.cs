using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour, IUpdateable
{
    private Dictionary<EnemyStatesEnum, EnemyState> enemyStateMap = new Dictionary<EnemyStatesEnum, EnemyState>();

    private EnemyState currentState;
    private EnemyState previousState;

    [SerializeField]
    private WorldGrid worldGrid;
    public WorldGrid WorldGrid { get { return worldGrid; } }

    private void Start()
    {
        enemyStateMap.Add(EnemyStatesEnum.EnemyWait, new EnemyWaitState(this));
        enemyStateMap.Add(EnemyStatesEnum.EnemyShoot, new EnemyShootingState(this));
        ChangeState(EnemyStatesEnum.EnemyWait);
    }

    public void ChangeState(EnemyStatesEnum newStateEnum)
    {
        EnemyState newState = enemyStateMap[newStateEnum];

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
public enum EnemyStatesEnum
{
    EnemyWait,
    EnemyShoot
}