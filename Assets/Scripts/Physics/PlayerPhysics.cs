using UnityEngine;
using System.Collections;

public class PlayerPhysics : BasePhysics
{
    public override Vector2 ComputeVelocity(Vector2 velocity, bool grounded, float maxSpeed)
    {
        Vector2 move = this.moveDirection;
        
        bool flipSprite = transform.rotation.eulerAngles.y == 180 ? (move.x > 0.01f) : (move.x < -0.01f);
        if (flipSprite)
        {
            float yRot = transform.rotation.y == 0 ? 180f : 0f;
            transform.localRotation = Quaternion.Euler(0, yRot, 0);
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
