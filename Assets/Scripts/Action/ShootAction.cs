using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : ActionContainer
{
    public override Action getPressAction()
    {
        return new ShootPressAction();
    }

    public override Action getReleaseAction()
    {
        return new ShootReleaseAction();
    }
}
