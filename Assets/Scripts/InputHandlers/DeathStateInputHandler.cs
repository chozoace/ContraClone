using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DeathStateInputHandler", menuName = "ScriptableObjects/DeathStateInputHandler", order = 2)]
public class DeathStateInputHandler : InputHandler
{
    public Dictionary<KeyCode, ActionContainer> inputMap = new Dictionary<KeyCode, ActionContainer>();
    MenuMoveAction menuMoveAction = new MenuMoveAction();
    public InputEvent inputEvent;

    [SerializeField]
    MenuControls controls;

    private void OnEnable()
    {
        inputMap.Add(controls.confirm, new MenuConfirmAction());
    }

    public override void HandleInput()
    {
        inputEvent.Raise(menuMoveAction);
        Action action = null;

        foreach (KeyCode keyCode in inputMap.Keys)
        {
            if (Input.GetKeyDown(keyCode) && inputMap[keyCode] != null)
            {
                action = inputMap[keyCode].getPressAction();
                inputEvent.Raise(action);
            }
            else if (Input.GetKeyUp(keyCode) && inputMap[keyCode] != null)
            {
                action = inputMap[keyCode].getReleaseAction();
                inputEvent.Raise(action);
            }
        }
    }
}

[Serializable]
public struct MenuControls
{
    public KeyCode confirm;
}
