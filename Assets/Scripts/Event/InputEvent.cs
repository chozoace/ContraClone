using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputEvent : ScriptableObject
{
    private List<InputEventListener> listeners = new List<InputEventListener>();

    public void Raise(KeyCode keyCode, bool wasPressed)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(keyCode, wasPressed);
        }
    }

    public void RegisterListener(InputEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(InputEventListener listener)
    {
        listeners.Remove(listener);
    }
}