using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    // 关联各个控件
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;

    private void Start()
    {
        // 给封装后的各个控件添加事件
        btnBegin.clickEvent += () =>
        {
            // 切换游戏场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            // 打开设置面板
            SettingPanel.Instance.ShowMe();
            HideMe();
            
        };
        btnQuit.clickEvent += () =>
        {
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            // 打开排行榜面板
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }
}
