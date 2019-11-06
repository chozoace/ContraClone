using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IActionable
{
    private List<string> lockedActions = new List<string>();

    public void ExecuteAction(Action action)
    {
        if (action != null && !lockedActions.Contains(action.getActionName()))
        {
            action.execute(this.gameObject);
        }
    }

    public List<string> GetLockedActions()
    {
        return lockedActions;
    }

    public void SetLockedActions(List<string> lockedActions)
    {
        this.lockedActions = lockedActions;
    }
}
