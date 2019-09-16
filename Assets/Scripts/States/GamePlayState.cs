﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    PlayerController player;

    public GamePlayState()
    {
        this.stateName = "GamePlayState";
        inputHandler = Resources.Load<PlayerInputHandler>("ScriptableObjects/InputHandlers/PlayerInputHandler");
    }

    public override void Enter()
    {
            
    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdateState()
    {
        GameController.Player.FixedUpdateSelf();
    }

    public override void UpdateState()
    {
        inputHandler.HandleInput();
        GameController.Player.UpdateSelf();
    }
}
