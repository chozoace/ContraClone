﻿using UnityEngine;
using System.Collections;

public abstract class BasePhysics : MonoBehaviour, IPhysics
{
    [SerializeField]
    protected WorldGrid worldGrid;

    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected PhysicsObject physicsObject;

    protected Vector2 moveDirection = Vector2.zero;
    public bool PhysicsEnabled { get; set; } = true;

    void Start()
    {
        worldGrid.AddToWorld(this.gameObject);
    }

    public abstract Vector2 ComputeVelocity(Vector2 velocity, bool grounded, float maxSpeed);
    public abstract void OnDeath();

    public void FixedUpdateSelf()
    {
        if(PhysicsEnabled)
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
        if (PhysicsEnabled)
            physicsObject.PhysicsUpdate();
    }
}
