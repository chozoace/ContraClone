using UnityEngine;
using System.Collections;

public class MainMenuButton : UIButton
{
    private void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    public override void execute()
    {
        //should load main menu....WHEN I HAVE ONE
        Application.Quit();
    }

    public override RectTransform GetRectTransform()
    {
        return rect;
    }
}
