using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IActionable
{
    public void ExecuteAction(Action action)
    {
        if (action != null)
        {
            action.execute(this.gameObject);
        }
    }
}
