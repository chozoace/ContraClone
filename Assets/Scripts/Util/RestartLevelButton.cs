using UnityEngine;
using System.Collections;

public class RestartLevelButton : UIButton
{
    public GameEvent restartLevelEvent;

    private void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    public override void execute()
    {
        restartLevelEvent.Raise();
    }

    public override RectTransform GetRectTransform()
    {
        return rect;
    }
}
