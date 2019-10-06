using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysics : IUpdateable
{
    Vector2 ComputeVelocity(Vector2 velocity, bool grounded, float maxSpeed);
    PhysicsObject GetPhysicsObject();
    Vector2 GetMoveDirection();
    void SetMoveDirection(Vector2 newDir);
    void UpdateGridPosition();
}
