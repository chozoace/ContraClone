using UnityEngine;
using System.Collections;

public class PlayerHitstunEnterAction : Action
{
    private float hitstunJumpTakeOffSpeed = 3;
    private float knockbackDistance = 0.8f;

    public void execute(GameObject obj)
    {
        PhysicsObject physicsObj = obj.GetComponent<PhysicsObject>();
        physicsObj.Velocity = new Vector2(physicsObj.Velocity.x, hitstunJumpTakeOffSpeed);

        IPhysics physics = obj.GetComponent<IPhysics>();
        physics.SetMoveDirection(new Vector2(knockbackDistance * (physics.GetMoveDirection().x * -1), 0));
    }

    public string getActionName()
    {
        return ActionNames.PlayerHitstunEnterAction.Value;
    }
}
