using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUILabel : CustomGUIControl
{
    protected override void DrawIsOff()
    {
        GUI.Label(guiPos.Pos, guiContent);
    }

    protected override void DrawIsOn()
    {
        GUI.Label(guiPos.Pos, guiContent, style);
    }
}
