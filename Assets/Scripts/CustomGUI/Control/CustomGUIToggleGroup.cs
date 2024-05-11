using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleGroup : MonoBehaviour
{
    [SerializeField]
    private CustomGUIToggle[] _toggles;

    // 注意只有游戏运行才能用
    void Start()
    {
        for (int i = 0; i < _toggles.Length; i++)
        {
            CustomGUIToggle tmp = _toggles[i];
            // 为每个Toggle添加一个一旦其值为true时, 其它Toggle变为false的委托
            // 闭包机制可以使委托函数内也能享用到外部资源!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            tmp.changeEvent += (value) =>
            {
                if (value)
                {
                    for (int j = 0; j < _toggles.Length; j++)
                    {
                        if (tmp != _toggles[j])
                        {
                            _toggles[j].isSel = false;
                        }
                    }
                }
            };
        }
    }
}
