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
        // 初始化音乐把保存的设置加载到游戏中
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
