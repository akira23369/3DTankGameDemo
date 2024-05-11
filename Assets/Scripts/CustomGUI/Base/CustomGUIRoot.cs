using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ������������������GUI��, ������������
[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] _customGUIControls;
    private void Start()
    {
        _customGUIControls = this.GetComponentsInChildren<CustomGUIControl>();
    }

    // ͳһ���������Ӷ�����صĿؼ��� ����
    private void OnGUI()
    {
        //if (!Application.isPlaying)       !!!!!!!!!!!!������ܲ�Ҫʡ!!!!!!!!!!!!!
        _customGUIControls = this.GetComponentsInChildren<CustomGUIControl>();
        for (int i = 0; i < _customGUIControls.Length; i++)
        {
            _customGUIControls[i].GUIDraw();
        }
    }
}
