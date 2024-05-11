using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down,
}
[System.Serializable]
public class CustomGUIPos
{
    private Rect _pos = new Rect(0, 0, 101, 100);
    // 屏幕九宫格对齐方式
    public E_Alignment_Type Screen_Alignment_Type = E_Alignment_Type.Center;
    // 控件中心点对齐方式
    public E_Alignment_Type Constrol_Center_Alignment_Type = E_Alignment_Type.Center;
    // 偏移位置
    public Vector2 dPos;
    // 宽高 
    public float Width = 100;
    public float Height = 50;
    public Rect Pos
    {
        get
        {
            CalcCenterPos();
            CalcPos();
            _pos.width = Width;
            _pos.height = Height;
            return _pos;
        }
    }
    // 控件中心点位置
    private Vector2 _centerPos;
    private void CalcCenterPos()
    {
        switch (Constrol_Center_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                _centerPos.x = -Width / 2;
                _centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                _centerPos.x = -Width / 2;
                _centerPos.y = -Height;
                break;
            case E_Alignment_Type.Left:
                _centerPos.x = 0;
                _centerPos.y = -Height / 2;
                break;
            case E_Alignment_Type.Right:
                _centerPos.x = -Width;
                _centerPos.y = -Height / 2;
                break;
            case E_Alignment_Type.Center:
                _centerPos.x = -Width / 2;
                _centerPos.y = -Height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                _centerPos.x = 0;
                _centerPos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                _centerPos.x = 0;
                _centerPos.y = -Height;
                break;
            case E_Alignment_Type.Right_Up:
                _centerPos.x = -Width;
                _centerPos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                _centerPos.x = -Width;
                _centerPos.y = -Height;
                break;
        }
    }
    private void CalcPos()
    {
        switch (Screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                _pos.x = Screen.width / 2 + _centerPos.x + dPos.x;
                _pos.y = Screen.height * 0 + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Down:
                _pos.x = Screen.width / 2 + _centerPos.x + dPos.x;
                _pos.y = Screen.height + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Left:
                _pos.x = Screen.width * 0 + _centerPos.x + dPos.x;
                _pos.y = Screen.height / 2 + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Right:
                _pos.x = Screen.width + _centerPos.x + dPos.x;
                _pos.y = Screen.height / 2 + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Center:
                _pos.x = Screen.width / 2 + _centerPos.x + dPos.x;
                _pos.y = Screen.height / 2 + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Left_Up:
                _pos.x = Screen.width * 0 + _centerPos.x + dPos.x;
                _pos.y = Screen.height * 0 + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Left_Down:
                _pos.x = Screen.width * 0 + _centerPos.x + dPos.x;
                _pos.y = Screen.height + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Right_Up:
                _pos.x = Screen.width + _centerPos.x + dPos.x;
                _pos.y = Screen.height * 0 + _centerPos.y + dPos.y;
                break;
            case E_Alignment_Type.Right_Down:
                _pos.x = Screen.width + _centerPos.x + dPos.x;
                _pos.y = Screen.height + _centerPos.y + dPos.y;
                break;
        }

    }
}