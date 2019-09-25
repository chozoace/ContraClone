using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InputEventListener : MonoBehaviour
{
    public InputEvent Event;
    private IActionable actionable; 

    private void OnEnable()
    {
        Event.RegisterListener(this);
        actionable = this.gameObject.GetComponent<IActionable>();
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    //might want to make a class that inherits from inputeventListener but does not execute the action but invokes something
    //like a unity event
    public void OnEventRaised(Action action)
    {
        actionable.ExecuteAction(action);
    }
}
