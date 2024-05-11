using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic _instance;
    public static BKMusic Instance => _instance;

    private AudioSource audio;
    void Awake()
    {
        _instance = this;
        audio = this.GetComponent<AudioSource>();
        // ��ʼ�����ְѱ�������ü��ص���Ϸ��
        ChangeValue(GameDataMgr.Instance.musicData.musicValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenMusic);
    }
    
    public void ChangeValue(float value)
    {
        audio.volume = value;
    }
    public void ChangeOpen(bool isOpen)
    {
        audio.mute = !isOpen;
    }
}
