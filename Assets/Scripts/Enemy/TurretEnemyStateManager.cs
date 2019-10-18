using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TurretEnemyActor))]
public class TurretEnemyStateManager : EnemyStateManager
{
    private void Start()
    {
        enemyStateMap.Add(TurretEnemyStateEnum.EnemyWait.ToString(), new EnemyWaitState(this));
        enemyStateMap.Add(TurretEnemyStateEnum.EnemyShoot.ToString(), new EnemyShootingState(this));
        ChangeState(TurretEnemyStateEnum.EnemyWait.ToString());
    }
    
}
public enum TurretEnemyStateEnum
{
    EnemyWait,
    EnemyShoot
}