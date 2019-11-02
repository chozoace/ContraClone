using UnityEngine;
using System.Collections;

public class JumpPressAction : Action
{
    public void execute(GameObject obj)
    {
        PhysicsObject physics = obj.GetComponent<PhysicsObject>();
        if (physics.IsGrounded)
        {
            physics.Velocity = new Vector2(physics.Velocity.x, physics.jumpTakeOffSpeed);
        }
    }

    public string getActionName()
    {
        return ActionNames.JumpPressAction.Value;
    }
}
