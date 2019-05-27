using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPressAction : Action
{
    public void execute(Actor actor)
    {
        actor.startShooting();
    }
}

