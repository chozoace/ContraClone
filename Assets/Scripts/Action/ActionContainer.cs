using UnityEngine;
using System.Collections;

public interface ActionContainer
{
    Action getPressAction();
    Action getReleaseAction();
}
