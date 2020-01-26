using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuComponent : MonoBehaviour, IActionable
{
    public List<UIButton> uiButtons;
    private int currentPointerIndex = 0;
    public RectTransform pointer;

    private void Start()
    {
        
    }

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
            currentPointerIndex = (currentPointerIndex + 1 > uiButtons.Count - 1) ? currentPointerIndex : currentPointerIndex + 1;
        }
        else if(dir < 0)
        {
            currentPointerIndex = (currentPointerIndex - 1 < 0) ? currentPointerIndex : currentPointerIndex - 1;
        }

        pointer.position = uiButtons[currentPointerIndex].GetRectTransform().position;
    }

    public void makeSelection()
    {
        uiButtons[currentPointerIndex].execute();
    }
}
