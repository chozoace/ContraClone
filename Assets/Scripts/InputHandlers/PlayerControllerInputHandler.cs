using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerControllerInputHandler", menuName = "ScriptableObjects/PlayerControllerInputHandler", order = 2)]
public class PlayerControllerInputHandler : InputHandler
{
    public Dictionary<KeyCode, ActionContainer> inputMap = new Dictionary<KeyCode, ActionContainer>();
    MoveInputAxisAction moveInputAxisAction = new MoveInputAxisAction();
    public InputEvent inputEvent;

    [SerializeField]
    PlayerControllerControlsMapping controls;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }
}

public struct PlayerControllerControlsMapping
{
    
}
