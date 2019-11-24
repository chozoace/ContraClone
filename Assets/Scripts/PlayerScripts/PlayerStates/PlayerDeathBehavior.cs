using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerDeathBehavior : StateMachineBehaviour
{
    private List<string> lockedStates = new List<string>();
    public GameStateManager gameStateManager;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameStateManager.ChangeGameState(GameStatesEnum.PlayerDeathState);
        //after player animation finishes, fade to black and restart from last checkpoint

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
}
