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

    public void OnEventRaised(Action action)
    {
        actionable.ExecuteAction(action);
    }
}
