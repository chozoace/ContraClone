using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWaitState : EnemyState
{
    private GameObject playerObject;
    private float alertRange = 2f;

    public EnemyWaitState(EnemyStateManager stateManager) : base(stateManager) { }

    public override void Enter()
    {

    }
    public override void Exit()
    {

    }
    public override void UpdateState()
    {
        if(playerObject == null)
        {
            //some kind of find nearest target?
            playerObject = stateManager.WorldGrid.FindInWorldGridByTag("Player");
        }
        else
        {
            if(Mathf.Abs(playerObject.transform.position.x - stateManager.gameObject.transform.position.x) < alertRange
                && this.stateManager.playerHp.Value > 0f)
            {
                stateManager.ChangeState(TurretEnemyStateEnum.EnemyShoot.ToString());
            }
        }
    }
    public override void FixedUpdateState()
    {

    }
}

