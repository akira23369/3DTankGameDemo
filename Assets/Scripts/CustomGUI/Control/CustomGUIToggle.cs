using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIToggle : CustomGUIControl
{
    // 单选的那个bool
    public bool isSel;
    private bool oldSel;
    // 当选中时所要执行的事件
    public event UnityAction<bool> changeEvent;
    protected override void DrawIsOff()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, guiContent);
        // 防止true true true一直调用事件执行 
        if (isSel != oldSel)
        {
            changeEvent?.Invoke(isSel);
            oldSel = isSel;
        }
    }

    protected override void DrawIsOn()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, guiContent, style);
        if (isSel != oldSel)
        {
            changeEvent?.Invoke(isSel);
            oldSel = isSel;
        }
    }
}
