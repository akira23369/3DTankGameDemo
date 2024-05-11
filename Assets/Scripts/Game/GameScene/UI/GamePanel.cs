using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    // 分数
    public CustomGUILabel labelScoreNum;
    // 时间
    public CustomGUILabel labelTime;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    // 血量
    public CustomGUITexture texHpRel;
    // hp血量图的宽
    public float hpW = 500;

    [HideInInspector]
    public int nowScore = 0;

    [HideInInspector]
    public float nowTime = 0;
    

    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            // 点击设置按钮后
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            // 点击退出按钮, 弹出确认框, 返回开始场景
            Time.timeScale = 0;
            QuitPanel.Instance.ShowMe();
        };
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        int time = (int)nowTime;
        labelTime.guiContent.text = "";
        if (time / 3600 > 0)
        {
            labelTime.guiContent.text += $"{time / 3600}时";
        }
        if (time % 3600 / 60 > 0 || time / 3600 > 0)
        {
            labelTime.guiContent.text += $"{time % 3600 / 60}分";
        }
        labelTime.guiContent.text += $"{time % 60}";
    }

    // 更新界面
    public void AddScroe(int value)
    {
        nowScore += value;
        labelScoreNum.guiContent.text = nowScore.ToString();
    }
    public void UpdateHp(int maxHp, int hp) => texHpRel.guiPos.Width = (float)hp / maxHp * hpW;
}
