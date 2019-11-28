using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public float fireRate = 1.0f;
    public float angleModifier;
    protected float timeStamp;
    protected bool shooting = false;
    protected IShooter owner;
    [SerializeField]
    protected GameObject bulletTypePrefab;
    [SerializeField]
    protected float bulletFireSpeed;
    protected List<Bullet> bulletList = new List<Bullet>();

    public abstract void shoot(Vector2 shootOrigin, Vector2 shootDirection);
    public void startShooting() { shooting = true; }
    public void stopShooting() { shooting = false; }

    public void OnEnable()
    {
        owner = this.gameObject.GetComponent<IShooter>(); 

        if(owner == null)
        {
            throw new MissingComponentException("GameObject does not implement IShooter");
        }
    }

    //bug happens with steps:
    //1. shoot up
    //2. let go of up but keep shoot held
    public void updateShooting()
    {
        if (shooting)
        {
            shoot(owner.GetShootOrigin(), owner.GetShootDirection());
        }
    }
}
