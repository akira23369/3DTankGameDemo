using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    // 外部提供给的按钮点击事件, Unity自带的事件
    public event UnityAction clickEvent;
    protected override void DrawIsOff()
    {
        if (GUI.Button(guiPos.Pos, guiContent))
        {
            clickEvent?.Invoke();
        }
    }

    protected override void DrawIsOn()
    {
        if (GUI.Button(guiPos.Pos, guiContent, style))
        {
            clickEvent?.Invoke();
        }
    }
}
