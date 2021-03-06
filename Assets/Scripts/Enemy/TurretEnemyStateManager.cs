﻿using UnityEngine;
using System.Collections;

public class TurretEnemyStateManager : EnemyStateManager
{
    private void Start()
    {
        enemyStateMap.Add(TurretEnemyStateEnum.EnemyWait.ToString(), new EnemyWaitState(this));
        enemyStateMap.Add(TurretEnemyStateEnum.EnemyShoot.ToString(), new EnemyShootingState(this));
        enemyStateMap.Add(TurretEnemyStateEnum.EnemyDeath.ToString(), new EnemyDeathState(this));
        ChangeState(TurretEnemyStateEnum.EnemyWait.ToString());
    }
    
}
public enum TurretEnemyStateEnum
{
    EnemyWait,
    EnemyShoot,
    EnemyDeath
}