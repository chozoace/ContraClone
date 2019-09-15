using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysics
{
    Vector2 ComputeVelocity(Vector2 velocity, bool grounded);

    PhysicsObject GetPhysicsObject();
}
