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
            // 处理音乐变化
        musicSlider.changeValue += (a) => GameDataMgr.Instance.ChangeBKValue(a);
        songSlider.changeValue += (a) => GameDataMgr.Instance.ChangeSongValue(a);
        musicToggle.changeEvent += (a) => GameDataMgr.Instance.OpenOrCloseMusic(a);
        songToggle.changeEvent += (a) => GameDataMgr.Instance.OpenOrCloseSong(a);
        btnClose.clickEvent += () =>
        {
            HideMe();
            // 如果当前是在开始场景, 需要把开始面板重新显示, 而游戏场景直接关闭就行
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
