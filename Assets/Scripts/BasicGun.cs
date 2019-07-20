using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{

    public BasicGun(Actor obj) : base(obj)
    {
        fireRate = 0.2f;
        bulletTypePrefab = Resources.Load("Prefabs/Bullets/BasicBullet") as GameObject;
        this.bulletFireSpeed = 3.0f;
    }

    public override void shoot(Vector2 shootDirection)
    {
        if (timeStamp <= Time.time)
        {
            GameObject bullet = Object.Instantiate(bulletTypePrefab, owner.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletFireSpeed;
            
            timeStamp = Time.time + fireRate;
        }
    }
}
