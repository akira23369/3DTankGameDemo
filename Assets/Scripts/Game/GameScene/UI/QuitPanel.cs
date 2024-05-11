using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuitYes;
    public CustomGUIButton btnQuitNo;
    public CustomGUIButton btnClose;

    void Start()
    {
        btnClose.clickEvent += () =>
        {
            HideMe();
        };
        btnQuitYes.clickEvent += () =>
        {
            // �ص���Ϸ����
            SceneManager.LoadScene("BeginScene");
        };
        btnQuitNo.clickEvent += () =>
        {
            HideMe();
        };
        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
