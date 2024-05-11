using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_onoff
{
    On,
    Off,
}
public abstract class CustomGUIControl : MonoBehaviour
{
    // GUI�ؼ���������    !!!!!!
    // λ����Ϣ
    public CustomGUIPos guiPos;
    // ��ʾ������Ϣ
    public GUIContent guiContent;
    // �Զ�����ʽ
    public GUIStyle style;
    // �Զ�����ʽ����
    public E_Style_onoff styleIsOn = E_Style_onoff.Off;

    // �ṩ�����Ŀؼ�����
    public void GUIDraw()
    {
        switch (styleIsOn)
        {
            case E_Style_onoff.On:
                // ��ʽ����ʱʹ�õĻ��ƺ���
                DrawIsOn();
                break;
            case E_Style_onoff.Off:
                DrawIsOff();
                break;
        }
    }
    protected abstract void DrawIsOn();
    protected abstract void DrawIsOff();
}