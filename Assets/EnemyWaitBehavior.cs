using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitBehavior : StateMachineBehaviour
{
    public float alertRange;
    public WorldGrid worldGrid;
    public FloatReference playerHp;

    private GameObject playerObject;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerObject == null)
        {
            //some kind of find nearest target?
            playerObject = worldGrid.FindInWorldGridByTag("Player");
        }
        else
        {
            if (Mathf.Abs(playerObject.transform.position.x - animator.gameObject.transform.position.x) < alertRange
                && playerHp.Value > 0f)
            {
                animator.SetBool("alerted", true);
            }
        }
    }
}
