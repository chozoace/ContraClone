using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun 
{
    protected float fireRate = 1.0f;
    protected float timeStamp = Time.time;
    protected bool shooting = false;
    protected Actor owner;
    protected GameObject bulletTypePrefab;
    protected float bulletFireSpeed;
    protected List<Bullet> bulletList = new List<Bullet>();

    public Gun(Actor obj)
    {
        owner = obj;
    }

    public abstract void shoot(Vector2 shootOrigin, Vector2 shootDirection);
    public void startShooting() { shooting = true; }
    public void stopShooting() { shooting = false; }

    //bug happens with steps:
    //1. shoot up
    //2. let go of up but keep shoot held
    public void updateShooting() { if(shooting) shoot(owner.ShootOrigin, owner.ShootDirection); }
}
