using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehavior : StateMachineBehaviour
{
    public WorldGrid worldGrid;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyStateManager>().ChangeState(TurretEnemyStateEnum.EnemyDeath.ToString());
        //after player animation finishes, fade to black and restart from last checkpoint

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //remove self from partitions
        worldGrid.RemoveFromWorld(animator.gameObject);
        GameObject.Destroy(animator.gameObject);
    }
}
