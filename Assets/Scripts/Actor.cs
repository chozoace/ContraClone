using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    
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

    public virtual void startShooting()
    {
        animator.SetBool("isShooting", true);
        if (canShoot)
        {
            this.equippedGun.startShooting();
            canShoot = false;
        }
    }
    public virtual void endShoot()
    {
        animator.SetBool("isShooting", false);
        if (canShoot == false)
        {
            this.equippedGun.stopShooting();
            canShoot = true;
        }
    }
    protected virtual void updateShootDirection()
    {

    }

    public virtual void Update()
    {
        updateShootDirection();
        equippedGun.updateShooting();
    }
}
