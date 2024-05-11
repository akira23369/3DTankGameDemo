using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUISlide musicSlider;
    public CustomGUISlide songSlider;
    public CustomGUIToggle musicToggle;
    public CustomGUIToggle songToggle;
    public CustomGUIButton btnClose;
    private void Start()
    {
            // �������ֱ仯
        musicSlider.changeValue += (a) => GameDataMgr.Instance.ChangeBKValue(a);
        songSlider.changeValue += (a) => GameDataMgr.Instance.ChangeSongValue(a);
        musicToggle.changeEvent += (a) => GameDataMgr.Instance.OpenOrCloseMusic(a);
        songToggle.changeEvent += (a) => GameDataMgr.Instance.OpenOrCloseSong(a);
        btnClose.clickEvent += () =>
        {
            HideMe();
            // �����ǰ���ڿ�ʼ����, ��Ҫ�ѿ�ʼ���������ʾ, ����Ϸ����ֱ�ӹرվ���
            if (SceneManager.GetActiveScene().name == "BeginScene") BeginPanel.Instance.ShowMe();
        };
        HideMe();
    }
    public void UpdateInfo()
    {
        MusicData musicData = GameDataMgr.Instance.musicData;
        musicSlider.nowValue = musicData.musicValue;
        songSlider.nowValue = musicData.songValue;
        musicToggle.isSel = musicData.isOpenMusic;
        songToggle.isSel = musicData.isOpenSong;
    }

    public override void ShowMe()
    {
        UpdateInfo();
        base.ShowMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
