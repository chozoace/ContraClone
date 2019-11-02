using UnityEngine;
using System.Collections;

public class PlayerHitstunEnterAction : Action
{
    private float hitstunJumpTakeOffSpeed = 3;

    public void execute(GameObject obj)
    {
        PhysicsObject physics = obj.GetComponent<PhysicsObject>();
        if (physics.IsGrounded)
        {
            physics.Velocity = new Vector2(physics.Velocity.x, hitstunJumpTakeOffSpeed);
        }
    }

    public string getActionName()
    {
        return ActionNames.PlayerHitstunEnterAction.Value;
    }
}
