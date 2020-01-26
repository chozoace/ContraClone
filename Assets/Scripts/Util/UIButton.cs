using UnityEngine;
using System.Collections;

public abstract class UIButton : MonoBehaviour
{
    protected RectTransform rect;

    public abstract void execute();
    public abstract RectTransform GetRectTransform();
}
