using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : ActionContainer
{
    public ShootAction()
    {
        this.pressAction = new ShootPressAction();
        this.releaseAction = new ShootReleaseAction();
    }
}
