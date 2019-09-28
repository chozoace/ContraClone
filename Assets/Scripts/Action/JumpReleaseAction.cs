using UnityEngine;
using System.Collections;

public class JumpReleaseAction : Action
{
    public void execute(GameObject obj)
    {
        PhysicsObject physics = obj.GetComponent<PhysicsObject>();
        if (!physics.IsGrounded && physics.Velocity.y > 0)
        {
            physics.Velocity = new Vector2(physics.Velocity.x, physics.Velocity.y * .5f);
        }
    }
}
