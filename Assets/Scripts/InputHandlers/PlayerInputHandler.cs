using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputHandler", menuName = "ScriptableObjects/PlayerInputHandler", order = 1)]
public class PlayerInputHandler : InputHandler
{
    [SerializeField]
    //https://answers.unity.com/questions/460727/how-to-serialize-dictionary-with-unity-serializati.html
    public Dictionary<KeyCode, ActionContainer> inputMap = new Dictionary<KeyCode, ActionContainer>();
    public InputEvent inputEvent;

    [SerializeField]
    PlayerControlsMapping controls;

    public ActionContainer buttonA;
    ActionContainer buttonD;
    ActionContainer buttonS;
    ActionContainer buttonW;
    ActionContainer buttonJ = new ShootAction();
    ActionContainer buttonSpace;

    public override void HandleInput()
    {
        Action action = null;

        //button press
        if (Input.GetKeyDown(KeyCode.J) && buttonJ != null)
        {
            action = buttonJ.getPressAction();
        }

        //button release
        if (Input.GetKeyUp(KeyCode.J) && buttonJ != null)
        {
            action = buttonJ.getReleaseAction();
        }

        //fires off an event
        inputEvent.Raise(action);
    }
}
[System.Serializable]
public struct PlayerControlsMapping
{
    public List<KeyCode> keyCodes;
}