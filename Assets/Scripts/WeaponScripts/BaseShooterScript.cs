using UnityEngine;
using System.Collections;

public abstract class BaseShooterScript : MonoBehaviour, IShooter
{
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected PhysicsObject physics;    
    [SerializeField]
    protected Gun equippedGun;
    [SerializeField]
    protected GameObject shootOriginObject;

    protected bool canShoot = true;
    protected Vector2 shootDirection = new Vector2(1, 0);
    public Vector2 ShootDirection { get { return shootDirection; } }
    protected Vector2 shootOrigin = Vector2.zero;
    public Vector2 ShootOrigin { get { return shootOrigin; } }

    public abstract void UpdateShootDirection(Vector2 newShootDirection);

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
        equippedGun.updateShooting();
    }

    public Vector2 GetShootOrigin()
    {
        return shootOrigin;
    }

    public Vector2 GetShootDirection()
    {
        return shootDirection;
    }

    public void FixedUpdateSelf()
    {
    }
}
