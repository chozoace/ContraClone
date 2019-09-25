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
    //or i can do both and only do actionable if its not null
    public void OnEventRaised(Action action)
    {
        actionable.ExecuteAction(action);
    }
}
