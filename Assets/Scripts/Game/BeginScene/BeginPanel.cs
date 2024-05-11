using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    // ���������ؼ�
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;

    private void Start()
    {
        // ����װ��ĸ����ؼ�����¼�
        btnBegin.clickEvent += () =>
        {
            // �л���Ϸ����
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            // ���������
            SettingPanel.Instance.ShowMe();
            HideMe();
            
        };
        btnQuit.clickEvent += () =>
        {
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            // �����а����
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }
}
