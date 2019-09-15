using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    IInputHandler inputHandler;
    PlayerController player;

    public GamePlayState()
    {
        this.stateName = "GamePlayState";
    }

    public override void Enter()
    {
            
    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void UpdateState()
    {
        player.HandleInput();
    }
}
