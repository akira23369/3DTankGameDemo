using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleGroup : MonoBehaviour
{
    [SerializeField]
    private CustomGUIToggle[] _toggles;

    // ע��ֻ����Ϸ���в�����
    void Start()
    {
        for (int i = 0; i < _toggles.Length; i++)
        {
            CustomGUIToggle tmp = _toggles[i];
            // Ϊÿ��Toggle���һ��һ����ֵΪtrueʱ, ����Toggle��Ϊfalse��ί��
            // �հ����ƿ���ʹί�к�����Ҳ�����õ��ⲿ��Դ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
