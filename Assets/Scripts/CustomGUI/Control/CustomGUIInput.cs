using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIInput : CustomGUIControl
{
    public event UnityAction<string> changeText;
    private string oldStr = "";
    protected override void DrawIsOff()
    {
        guiContent.text = GUI.TextField(guiPos.Pos, guiContent.text);
        // 当输入框变化时调用的委托函数
        if (oldStr != guiContent.text)
        {
            changeText?.Invoke(guiContent.text);
            oldStr = guiContent.text;
        }
    }

    protected override void DrawIsOn()
    {
        guiContent.text = GUI.TextField(guiPos.Pos, guiContent.text, style);
        if (oldStr != guiContent.text)
        {
            changeText?.Invoke(guiContent.text);
            oldStr = guiContent.text;
        }
    }
}
