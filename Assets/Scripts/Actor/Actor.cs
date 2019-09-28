using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IShooter, IPhysics, IActionable
{
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected Vector2 moveDirection = Vector2.zero;
    
    protected Gun equippedGun;
    protected bool canShoot = true;
    protected Vector2 shootDirection;
    public Vector2 ShootDirection { get { return shootDirection; } }
    protected Vector2 shootOrigin = Vector2.zero;
    public Vector2 ShootOrigin { get { return shootOrigin; } }

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

    public void UpdateShootDirection(Vector2 newShootDirection)
    {
        //This is temporary until I figure out a way to determine shoot origin based on state of Actor
        shootOrigin = Vector2.zero;
        //shooting straight up idle
        if (newShootDirection.x != 0 || newShootDirection.y == 1)
        {
            shootDirection.x = newShootDirection.x;
        }
        shootDirection.y = newShootDirection.y;
        //to adjust standing shooting
        if (shootDirection.y == 0)
        {
            shootOrigin = new Vector2(0, 0.05f);
        }
        //to adjust running down shooting
        else if (shootDirection.x != 0 && shootDirection.y < 0)
        {
            shootOrigin = new Vector2(.06f * newShootDirection.x, 0);
        }
        //crouching shooting
        if (newShootDirection.y == -1 && GetPhysicsObject().Velocity.x == 0)
        {
            shootDirection.y = 0;
            shootOrigin = new Vector2(0, -0.08f);
        }

        animator.SetInteger("aimY", (int)newShootDirection.y);
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

    public void UpdateSelf()
    {
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

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public void SetMoveDirection(Vector2 newDir)
    {
        moveDirection = newDir;
    }
}
