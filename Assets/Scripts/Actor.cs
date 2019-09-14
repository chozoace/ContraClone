using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IShooter
{
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected IInputHandler inputHandler;
    
    protected Gun equippedGun;
    protected bool canShoot = true;
    protected Vector2 shootDirection;
    public Vector2 ShootDirection { get { return shootDirection; } }
    protected Vector2 shootOrigin = Vector2.zero;
    public Vector2 ShootOrigin { get { return shootOrigin; } }

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
    protected virtual void UpdateShootDirection()
    {

    }

    public virtual void Update()
    {
        UpdateShootDirection();
        equippedGun.updateShooting();
    }
}
