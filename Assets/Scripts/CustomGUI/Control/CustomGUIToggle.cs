using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIToggle : CustomGUIControl
{
    // ��ѡ���Ǹ�bool
    public bool isSel;
    private bool oldSel;
    // ��ѡ��ʱ��Ҫִ�е��¼�
    public event UnityAction<bool> changeEvent;
    protected override void DrawIsOff()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, guiContent);
        // ��ֹtrue true trueһֱ�����¼�ִ�� 
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
