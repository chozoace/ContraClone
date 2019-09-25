using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputHandler", menuName = "ScriptableObjects/PlayerInputHandler", order = 1)]
public class PlayerInputHandler : InputHandler
{
    public Dictionary<KeyCode, ActionContainer> inputMap = new Dictionary<KeyCode, ActionContainer>();
    public InputEvent inputEvent;

    [SerializeField]
    PlayerControlsMapping controls;

    private void OnEnable()
    {
        inputMap.Add(controls.shootButton, new ShootAction());
    }

    public override void HandleInput()
    {
        Action action = null;

        //button press
        if (Input.GetKeyDown(controls.shootButton) && inputMap[controls.shootButton] != null)
        {
            action = inputMap[controls.shootButton].getPressAction();
        }

        //button release
        if (Input.GetKeyUp(KeyCode.J) && inputMap[controls.shootButton] != null)
        {
            action = inputMap[controls.shootButton].getReleaseAction();
        }

        //fires off an event
        inputEvent.Raise(action);
    }
}
[System.Serializable]
public struct PlayerControlsMapping
{
    public KeyCode shootButton;
}