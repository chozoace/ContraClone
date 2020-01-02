using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuComponent : MonoBehaviour, IActionable
{
    public List<RectTransform> pointerPositions;
    private int currentPointerIndex = 0;
    public RectTransform pointer;

    public void ExecuteAction(Action action)
    {
        if (action != null)
        {
            action.execute(this.gameObject);
        }
    }

    public List<string> GetLockedActions()
    {
        return new List<string>();
    }

    public void SetLockedActions(List<string> lockedActions)
    {
        
    }

    public void movePointer(int dir)
    {
        if(dir > 0)
        {
            currentPointerIndex = (currentPointerIndex + 1 > pointerPositions.Count - 1) ? 0 : currentPointerIndex + 1;
        }
        else if(dir < 0)
        {
            currentPointerIndex = (currentPointerIndex - 1 < 0) ? 0 : currentPointerIndex - 1;
        }

        pointer.position = pointerPositions[currentPointerIndex].position;
    }

    public void makeSelection()
    {

    }
}
