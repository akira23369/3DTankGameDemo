using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    // �ⲿ�ṩ���İ�ť����¼�, Unity�Դ����¼�
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
