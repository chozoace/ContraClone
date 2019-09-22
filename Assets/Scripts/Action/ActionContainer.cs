using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public abstract class ActionContainer
{
    public abstract Action getPressAction();
    public abstract Action getReleaseAction();
}
