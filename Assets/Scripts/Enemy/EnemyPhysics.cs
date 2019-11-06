using UnityEngine;
using System.Collections;

public class EnemyPhysics : BasePhysics
{
    public override Vector2 ComputeVelocity(Vector2 velocity, bool grounded, float maxSpeed)
    {
        Vector2 move = this.moveDirection;

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        return new Vector2(move.x * maxSpeed, velocity.y);
    }

    public override void OnDeath()
    {
        Debug.Log("EnemyDeath");
    }
}
