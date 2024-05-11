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
            // ��¼���ݵ����а�, �ؿ�ʼ
            GameDataMgr.Instance.AddRankInfo(input.guiContent.text, GamePanel.Instance.nowScore,
                GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
