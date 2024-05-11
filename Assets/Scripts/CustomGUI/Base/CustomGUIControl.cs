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
    // GUI控件公共部分    !!!!!!
    // 位置信息
    public CustomGUIPos guiPos;
    // 显示内容信息
    public GUIContent guiContent;
    // 自定义样式
    public GUIStyle style;
    // 自定义样式开关
    public E_Style_onoff styleIsOn = E_Style_onoff.Off;

    // 提供公共的控件绘制
    public void GUIDraw()
    {
        switch (styleIsOn)
        {
            case E_Style_onoff.On:
                // 样式开启时使用的绘制函数
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