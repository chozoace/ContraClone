using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    PlayerController player;

    public GamePlayState()
    {
        this.stateName = "GamePlayState";
        inputHandler = Resources.Load<PlayerInputHandler>("ScriptableObjects/InputHandlers/PlayerInputHandler");
        //uggh
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public override void Enter()
    {
            
    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdateState()
    {
        player.FixedUpdateSelf();
    }

    public override void UpdateState()
    {
        //only for PlayerInputHandler
        player.ExecuteAction(inputHandler.HandleInput());
        //this will be moved to partition logic
        player.UpdateSelf();
    }
}
