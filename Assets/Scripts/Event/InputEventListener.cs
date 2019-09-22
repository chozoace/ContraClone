using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InputEventListener : MonoBehaviour
{
    public InputEvent Event;
    public InputResponse Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(KeyCode keyCode, bool wasPressed)
    {
        Response.Invoke(keyCode, wasPressed);
    }
}
