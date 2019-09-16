﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputHandler", menuName = "ScriptableObjects/PlayerInputHandler", order = 1)]
public class PlayerInputHandler : InputHandler
{
    [SerializeField]
    int value;

    ActionContainer buttonA;
    ActionContainer buttonD;
    ActionContainer buttonS;
    ActionContainer buttonW;
    ActionContainer buttonJ = new ShootAction();
    ActionContainer buttonSpace;

    public override void HandleInput()
    {
        HandlePlayerInput();
    }

    public void HandlePlayerInput()
    {
        Action actionToReturn = null;

        //button press
        if (Input.GetKeyDown(KeyCode.J) && buttonJ != null)
        {
            actionToReturn = buttonJ.getPressAction();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && buttonSpace != null)
        {
            actionToReturn = buttonSpace.getPressAction();
        }

        //button release
        if (Input.GetKeyUp(KeyCode.J) && buttonJ != null)
        {
            actionToReturn = buttonJ.getReleaseAction();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && buttonSpace != null)
        {
            actionToReturn = buttonSpace.getReleaseAction();
        }

        GameController.Player.ExecuteAction(actionToReturn);
    }
}
