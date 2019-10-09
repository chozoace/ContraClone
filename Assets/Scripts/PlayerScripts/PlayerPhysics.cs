﻿using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour, IPhysics
{
    [SerializeField]
    WorldGrid worldGrid;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private PhysicsObject physicsObject;

    Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
        worldGrid.AddToWorld(this.gameObject);
    }

    public Vector2 ComputeVelocity(Vector2 velocity, bool grounded, float maxSpeed)
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

    public void FixedUpdateSelf()
    {
        physicsObject.PhysicsFixedUpdate();
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public PhysicsObject GetPhysicsObject()
    {
        return physicsObject;
    }

    public void SetMoveDirection(Vector2 newDir)
    {
        moveDirection = newDir;
    }

    public void UpdateGridPosition(Vector2 oldPos)
    {
        worldGrid.Move(this.gameObject, oldPos);
    }

    public void UpdateSelf()
    {
        physicsObject.PhysicsUpdate();
    }
}
