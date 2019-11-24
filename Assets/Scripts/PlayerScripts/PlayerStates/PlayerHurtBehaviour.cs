using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : StateMachineBehaviour
{
    private List<string> lockedActions = new List<string>();
    private Action hitstunEnterAction = new PlayerHitstunEnterAction();

    private float knockbackDistance = 0.8f;

    private void Awake()
    {
        lockedActions.Add(ActionNames.JumpPressAction.Value);
        lockedActions.Add(ActionNames.JumpReleaseAction.Value);
        lockedActions.Add(ActionNames.ShootPressAction.Value);
        lockedActions.Add(ActionNames.ShootReleaseAction.Value);
        lockedActions.Add(ActionNames.MoveInputAxisAction.Value);
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<IShooter>().EndShooting();
        IActionable actor = animator.gameObject.GetComponent<IActionable>();
        actor.SetLockedActions(lockedActions);

        //make player jump
        actor.ExecuteAction(hitstunEnterAction);
        //start timer?
        animator.gameObject.GetComponent<IDestructable>().StopHitstun();
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
