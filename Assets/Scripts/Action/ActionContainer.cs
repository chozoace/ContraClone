using UnityEngine;
using System.Collections;
using System;


public abstract class ActionContainer
{
    protected Action pressAction;
    protected Action releaseAction;

    public Action getPressAction()
    {
        return pressAction;
    }

    public Action getReleaseAction()
    {
        return releaseAction;
    }
}
