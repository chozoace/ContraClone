using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : StateMachineBehaviour
{
    private List<string> lockedStates = new List<string>();
    private Action hitstunEnterAction = new PlayerHitstunEnterAction();

    private void Awake()
    {
        lockedStates.Add(ActionNames.JumpPressAction.Value);
        lockedStates.Add(ActionNames.JumpReleaseAction.Value);
        lockedStates.Add(ActionNames.ShootPressAction.Value);
        lockedStates.Add(ActionNames.ShootReleaseAction.Value);
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<IShooter>().EndShooting();
        IActionable actor = animator.gameObject.GetComponent<IActionable>();
        actor.SetLockedActions(lockedStates);

        //make player jump
        actor.ExecuteAction(hitstunEnterAction);
        //start timer?
        actor.StopHitstun();
    }

    private IEnumerator StopHitstun(Animator animator)
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("hitstun", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
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
