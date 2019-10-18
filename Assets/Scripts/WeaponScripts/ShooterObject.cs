using UnityEngine;
using System.Collections;

public class ShooterObject : MonoBehaviour, IShooter
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    PhysicsObject physics;

    //with these variables, I'm going to need an abstract class
    [SerializeField]
    private Gun equippedGun;
    protected bool canShoot = true;
    protected Vector2 shootDirection = new Vector2(1, 0);
    public Vector2 ShootDirection { get { return shootDirection; } }
    protected Vector2 shootOrigin = Vector2.zero;
    public Vector2 ShootOrigin { get { return shootOrigin; } }

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
        if (newShootDirection.y == -1 && physics.Velocity.x == 0)
        {
            shootDirection.y = 0;
            shootOrigin = new Vector2(0, -0.08f);
        }

        animator.SetInteger("aimY", (int)newShootDirection.y);
        animator.SetInteger("aimX", (int)newShootDirection.x);
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
        equippedGun.updateShooting();
    }

    public void FixedUpdateSelf()
    {
    }
}
