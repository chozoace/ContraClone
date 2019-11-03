using UnityEngine;
using System.Collections;

public class PlayerPhysics : BasePhysics
{
    public override Vector2 ComputeVelocity(Vector2 velocity, bool grounded, float maxSpeed)
    {
        Vector2 move = this.moveDirection;

        bool flipSprite = spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        return new Vector2(move.x * maxSpeed, velocity.y);
    }
}
