using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShootingState : EnemyState
{
    private GameObject playerObject;
    private float alertRange = 2f;
    private float yAimThreshold = .2f;
    private float xAimThreshold = .2f;
    private bool isShooting = false;
    ActionContainer shootAction;
    private SpriteRenderer spriteRenderer;

    public EnemyShootingState(EnemyStateManager stateManager) : base(stateManager)
    {
        shootAction = new ShootAction();
        spriteRenderer = stateManager.gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        stateManager.gameObject.GetComponent<Actor>().ExecuteAction(shootAction.getReleaseAction());
        isShooting = false;
    }

    public override void UpdateState()
    {
        if (playerObject == null)
        {
            playerObject = stateManager.WorldGrid.FindInWorldGridByTag("Player");
        }
        else
        {
            if (Mathf.Abs(playerObject.transform.position.x - stateManager.gameObject.transform.position.x) > alertRange
                || this.stateManager.playerHp.Value <= 0)
            {
                stateManager.ChangeState(TurretEnemyStateEnum.EnemyWait.ToString());
            }
            else
            {
                UpdateShootDirection();
                if (isShooting == false)
                {
                    stateManager.gameObject.GetComponent<Actor>().ExecuteAction(shootAction.getPressAction());
                    isShooting = true;
                }                
            }
        }
    }

    private void UpdateShootDirection()
    {
        Vector2 newDir = new Vector2(Mathf.Clamp(stateManager.gameObject.transform.position.x - playerObject.transform.position.x,
            -1, 1), Mathf.Clamp(stateManager.gameObject.transform.position.y - playerObject.transform.position.y,
            -1, 1));

        newDir.x = (newDir.x >= 0) ? -1 : 1;
        if(Mathf.Abs(newDir.y) > yAimThreshold)
        {
            newDir.y = (newDir.y > 0) ? -1 : 1;
        }
        else
        {
            newDir.y = 0;
        }

        IShooter shooter = stateManager.gameObject.GetComponent<IShooter>();
        if (shooter != null)
        {
            shooter.UpdateShootDirection(newDir);
        }

        bool flipSprite = spriteRenderer.flipX ? (newDir.x > 0) : (newDir.x <= 0);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public override void FixedUpdateState()
    {

    }
}
