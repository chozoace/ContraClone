using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitBehavior : StateMachineBehaviour
{
    public float alertRange;
    public WorldGrid worldGrid;
    public FloatReference playerHp;

    private GameObject playerObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
