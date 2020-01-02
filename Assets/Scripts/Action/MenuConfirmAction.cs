using UnityEngine;
using System.Collections;

public class MenuConfirmAction : ActionContainer
{
    public MenuConfirmAction()
    {
        this.pressAction = new MenuConfirmPressAction();
        this.releaseAction = new MenuConfirmReleaseAction();
    }
}

public class MenuConfirmPressAction : Action
{
    public void execute(GameObject obj)
    {
        MenuComponent menu = obj.GetComponent<MenuComponent>();

        if (menu != null)
        {
            menu.makeSelection();
        }
    }

    public string getActionName()
    {
        return ActionNames.MenuConfirmAction.Value;
    }
}

public class MenuConfirmReleaseAction : Action
{
    public void execute(GameObject obj)
    {
        
    }

    public string getActionName()
    {
        return "";
    }
}
