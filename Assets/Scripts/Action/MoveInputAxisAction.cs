using UnityEngine;
using System.Collections;

public class MoveInputAxisAction : Action
{
    public void execute(GameObject obj)
    {
        IPhysics physics = obj.GetComponent<IPhysics>();

        Vector2 newDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(Mathf.Abs(newDir.x) < 1 && Mathf.Abs(newDir.x) > 0)
        {
            newDir.x = 0;
        }
        if (Mathf.Abs(newDir.y) < 1 && Mathf.Abs(newDir.y) > 0)
        {
            newDir.y = 0;
        }
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
