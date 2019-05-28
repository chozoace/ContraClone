using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : PhysicsObject
{
    Action shootAction;
    Action deathAction;
    Action jumpAction;
    protected Gun equippedGun;
    protected bool canShoot = true;
    protected Vector2 shootDirection;
    public Vector2 ShootDirection { get { return shootDirection; } }

    public virtual void startShooting()
    {
        if (canShoot)
        {
            this.equippedGun.startShooting();
            canShoot = false;
        }
    }
    public virtual void endShoot()
    {
        if (canShoot == false)
        {
            this.equippedGun.stopShooting();
            canShoot = true;
        }
    }

    protected virtual void updateShootDirection()
    {

    }

    protected override void Update()
    {
        updateShootDirection();
        equippedGun.updateShooting();
        base.Update();
    }
}
