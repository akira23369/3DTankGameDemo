using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUITexture : CustomGUIControl
{
    public ScaleMode mode = ScaleMode.StretchToFill;
    protected override void DrawIsOff()
    {
        GUI.DrawTexture(guiPos.Pos, guiContent.image, mode);
    }

    protected override void DrawIsOn()
    {
        GUI.DrawTexture(guiPos.Pos, guiContent.image, mode);
    }
}
