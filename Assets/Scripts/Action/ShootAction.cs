using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : ActionContainer
{
    public Action getPressAction()
    {
        return new ShootPressAction();
    }

    public Action getReleaseAction()
    {
        return new ShootReleaseAction();
    }
}
