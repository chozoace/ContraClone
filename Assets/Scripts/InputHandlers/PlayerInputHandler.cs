using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputHandler", menuName = "ScriptableObjects/PlayerInputHandler", order = 1)]
public class PlayerInputHandler : InputHandler
{
    public Dictionary<KeyCode, ActionContainer> inputMap = new Dictionary<KeyCode, ActionContainer>();
    MoveInputAxisAction moveInputAxisAction = new MoveInputAxisAction();
    public InputEvent inputEvent;

    [SerializeField]
    PlayerControlsMapping controls;

    private void OnEnable()
    {
        inputMap.Add(controls.shootButton, new ShootAction());
        inputMap.Add(controls.jumpButton, new JumpAction());
    }

    public override void HandleInput()
    {
        this.HandleDirectionInput();
        this.HandleButtonInput();
    }

    private void HandleButtonInput()
    {
        Action action = null;
        
        //simultaneous buttons being a seperate action not handled
        foreach(KeyCode keyCode in inputMap.Keys)
        {
            if(Input.GetKeyDown(keyCode) && inputMap[keyCode] != null)
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

    private void HandleDirectionInput()
    {
        inputEvent.Raise(moveInputAxisAction);
    }
}
[System.Serializable]
public struct PlayerControlsMapping
{
    public KeyCode shootButton;
    public KeyCode jumpButton;
}