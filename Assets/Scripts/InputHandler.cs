﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    static InputHandler instance;

    ActionContainer buttonA;
    ActionContainer buttonD;
    ActionContainer buttonS;
    ActionContainer buttonW;
    ActionContainer buttonJ;
    ActionContainer buttonSpace;

    public static InputHandler Instance()
    {
        if(instance == null)
        {
            instance = new InputHandler();
        }
        return instance;
    }

    public InputHandler()
    {
        //default controls
        buttonJ = new ShootAction();
    }

    public Action handleInput()
    {
        Action actionToReturn = null;

        //button press
        if(Input.GetKeyDown(KeyCode.J))
        {
            actionToReturn = buttonJ.getPressAction();
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            actionToReturn = buttonSpace.getPressAction();
        }

        //button release
        if (Input.GetKeyUp(KeyCode.J))
        {
            actionToReturn = buttonJ.getReleaseAction();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            actionToReturn = buttonSpace.getReleaseAction();
        }

        return actionToReturn;
    }

}
