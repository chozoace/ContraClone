using UnityEngine;
using System.Collections;

public class MenuMoveAction : Action
{
    public void execute(GameObject obj)
    {
        Vector2 newDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MenuComponent menu = obj.GetComponent<MenuComponent>();

        if (menu != null)
        {
            menu.movePointer((int)newDir.x);
        }

    }

    public string getActionName()
    {
        return ActionNames.MenuMoveAction.Value;
    }
}
