using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 该类是用来管理所有GUI的, 而且所见所得
[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] _customGUIControls;
    private void Start()
    {
        _customGUIControls = this.GetComponentsInChildren<CustomGUIControl>();
    }

    // 统一控制所有子对象挂载的控件的 绘制
    private void OnGUI()
    {
        //if (!Application.isPlaying)       !!!!!!!!!!!!这个性能不要省!!!!!!!!!!!!!
        _customGUIControls = this.GetComponentsInChildren<CustomGUIControl>();
        for (int i = 0; i < _customGUIControls.Length; i++)
        {
            _customGUIControls[i].GUIDraw();
        }
    }
}
