using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{
    void Start()
    {
        this.timeStamp = Time.time;
    }

    public override void shoot(Vector2 shootOrigin, Vector2 shootDirection)
    {
        Vector2 modifiedBulletFireSpeed = new Vector2(bulletFireSpeed, bulletFireSpeed);
        Vector2 bulletDirection = new Vector2(shootDirection.normalized.x * modifiedBulletFireSpeed.x, shootDirection.normalized.y * modifiedBulletFireSpeed.y);
        if (Mathf.Abs(shootDirection.x) == 1 && Mathf.Abs(shootDirection.y) == 1)
        {
            Vector2 modifiedAngle = new Vector2(Mathf.Cos(angleModifier * Mathf.Deg2Rad), Mathf.Sin(angleModifier * Mathf.Deg2Rad)).normalized;
            bulletDirection = new Vector2(modifiedBulletFireSpeed.x * modifiedAngle.x * shootDirection.x, modifiedBulletFireSpeed.y * modifiedAngle.y * shootDirection.y);
        }       

        if (timeStamp <= Time.time)
        {
            //If cooldown has passed
            bool createBullet = true;
            if (this.bulletList.Count > 0)
            {
                foreach (Bullet bulletObject in bulletList)
                {
                    if (!bulletObject.Exists)
                    {
                        createBullet = false;
                        bulletObject.ReuseBullet(shootOrigin, 0, bulletDirection);
                        break;
                    }
                }
            }
            if(createBullet)
            {
                GameObject bullet = Object.Instantiate(bulletTypePrefab, shootOrigin, Quaternion.identity);
                bullet.GetComponent<Bullet>().Owner = this.gameObject;
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection;
                bulletList.Add(bullet.GetComponent<Bullet>());
            }
            
            timeStamp = Time.time + fireRate;
        }
    }
}
