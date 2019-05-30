using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{

    public BasicGun(Actor obj) : base(obj)
    {
        fireRate = 0.5f;
    }

    public override void shoot(Vector2 shootDirection)
    {
        if (timeStamp <= Time.time)
        {
            Debug.Log("Player Shoot");
            
            timeStamp = Time.time + fireRate;
        }
    }
}
