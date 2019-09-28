using UnityEngine;
using System.Collections;
using System;


public abstract class ActionContainer
{
    protected Action pressAction;
    protected Action releaseAction;
    protected Action inputAxisAction;

    public Action getPressAction()
    {
        return pressAction;
    }

    public Action getReleaseAction()
    {
        return releaseAction;
    }

    public Action getInputAxisAction()
    {
        return inputAxisAction;
    }
}
