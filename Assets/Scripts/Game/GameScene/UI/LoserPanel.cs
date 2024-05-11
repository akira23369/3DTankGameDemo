using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoserPanel : BasePanel<LoserPanel>
{
    public CustomGUIButton btnYes;
    public CustomGUIButton btnNo;

    private void Start()
    {
        btnYes.clickEvent += () =>
        {
            Time.timeScale = 1;
            // 再次加载场景
            SceneManager.LoadScene("GameScene");
        };
        btnNo.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
