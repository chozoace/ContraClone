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
            //GetComponent<CapsuleCollider2D>().offset = new Vector2(GetComponent<CapsuleCollider2D>().offset.x * -1, GetComponent<CapsuleCollider2D>().offset.y);
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        return new Vector2(move.x * maxSpeed, velocity.y);
    }

    public override void OnDeath()
    {
        PhysicsEnabled = false;
        
    }
}
