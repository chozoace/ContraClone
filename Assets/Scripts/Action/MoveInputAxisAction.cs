using UnityEngine;
using System.Collections;

public class MoveInputAxisAction : Action
{
    public void execute(GameObject obj)
    {
        IPhysics physics = obj.GetComponent<IPhysics>();
        Vector2 newDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        physics.SetMoveDirection(newDir);

        IShooter shooter = obj.GetComponent<IShooter>();
        if(shooter != null)
        {
            shooter.UpdateShootDirection(newDir);
        }
    }

    public string getActionName()
    {
        return ActionNames.MoveInputAxisAction.Value;
    }
}
