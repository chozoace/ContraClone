using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IShooter, IPhysics, IActionable
{
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    
    protected Gun equippedGun;
    protected bool canShoot = true;
    protected Vector2 shootDirection;
    public Vector2 ShootDirection { get { return shootDirection; } }
    protected Vector2 shootOrigin = Vector2.zero;
    public Vector2 ShootOrigin { get { return shootOrigin; } }

    public abstract Vector2 ComputeVelocity(Vector2 velocity, bool grounded);
    public abstract void UpdateShootDirection();

    public void ExecuteAction(Action action)
    {
        if (action != null)
        {
            action.execute(this.gameObject);
        }
    }

    public void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void StartShooting()
    {
        animator.SetBool("isShooting", true);
        if (canShoot)
        {
            this.equippedGun.startShooting();
            canShoot = false;
        }
    }
    public void EndShooting()
    {
        animator.SetBool("isShooting", false);
        if (canShoot == false)
        {
            this.equippedGun.stopShooting();
            canShoot = true;
        }
    }

    public void UpdateSelf()
    {
        UpdateShootDirection();
        equippedGun.updateShooting();
        GetPhysicsObject().PhysicsUpdate();
    }

    public void FixedUpdateSelf()
    {
        GetPhysicsObject().PhysicsFixedUpdate();
    }

    public void UpdateGridPosition()
    {
        //update current partition here
    }

    public PhysicsObject GetPhysicsObject()
    {
        return GetComponent<PhysicsObject>();
    }
}
