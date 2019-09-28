using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    [SerializeField] public float maxSpeed = 7;
    [SerializeField] public float jumpTakeOffSpeed = 7;

    new void Awake()
    {
        base.Awake();
        this.equippedGun = new BasicGun(this);

        shootDirection.x = 1;
    }
}