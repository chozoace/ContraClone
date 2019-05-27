using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun 
{
    protected float fireRate = 1.0f;
    protected float timeStamp = Time.time;
    protected bool shooting = false;
    protected Actor owner;

    public Gun(Actor obj)
    {
        owner = obj;
    }

    public abstract void shoot(Vector2 shootDirection);
    public void startShooting() { shooting = true; }
    public void stopShooting() { shooting = false; }

    public void updateShooting() { if(shooting) shoot(owner.ShootDirection); }
}
