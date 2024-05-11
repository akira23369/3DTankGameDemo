using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput input;
    public CustomGUIButton btnYes;
    void Start()
    {
        btnYes.clickEvent += () =>
        {
            Time.timeScale = 1;
            // 记录数据到排行榜, 回开始
            GameDataMgr.Instance.AddRankInfo(input.guiContent.text, GamePanel.Instance.nowScore,
                GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
