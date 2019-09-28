using UnityEngine;
using System.Collections;

public class JumpAction : ActionContainer
{
    public JumpAction()
    {
        this.pressAction = new JumpPressAction();
        this.releaseAction = new JumpReleaseAction();
    }
}
