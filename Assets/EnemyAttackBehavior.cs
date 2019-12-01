using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : StateMachineBehaviour
{
    public float alertRange;
    public WorldGrid worldGrid;
    public FloatReference playerHp;
    public float yAimThreshold = .2f;
    ActionContainer shootAction = new ShootAction();

    private GameObject playerObject;
    private IShooter shooterObj;
    private SpriteRenderer renderer;
    private bool isShooting = false;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shooterObj = animator.GetComponent<IShooter>();
        renderer = animator.GetComponent<SpriteRenderer>();
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerObject == null)
        {
            //some kind of find nearest target?
            playerObject = worldGrid.FindInWorldGridByTag("Player");
        }
        else
        {
            if (Mathf.Abs(playerObject.transform.position.x - animator.gameObject.transform.position.x) > alertRange
                || playerHp.Value <= 0)
            {
                animator.SetBool("alerted", false);
            }
            else
            {
                UpdateShootDirection();
                if (isShooting == false)
                {
                    animator.gameObject.GetComponent<Actor>().ExecuteAction(shootAction.getPressAction());
                    isShooting = true;
                }
            }
        }
    }

    private void UpdateShootDirection()
    {
        Vector2 newDir = new Vector2(Mathf.Clamp(renderer.gameObject.transform.position.x - playerObject.transform.position.x,
            -1, 1), Mathf.Clamp(renderer.gameObject.transform.position.y - playerObject.transform.position.y,
            -1, 1));

        newDir.x = (newDir.x >= 0) ? -1 : 1;
        if (Mathf.Abs(newDir.y) > yAimThreshold)
        {
            newDir.y = (newDir.y > 0) ? -1 : 1;
        }
        else
        {
            newDir.y = 0;
        }
        
        if (shooterObj != null)
        {
            shooterObj.UpdateShootDirection(newDir);
        }

        //change this to 180 rotation
        bool flipSprite = renderer.flipX ? (newDir.x > 0) : (newDir.x <= 0);
        if (flipSprite)
        {
            renderer.flipX = !renderer.flipX;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Actor>().ExecuteAction(shootAction.getReleaseAction());
        isShooting = false;
    }

}
