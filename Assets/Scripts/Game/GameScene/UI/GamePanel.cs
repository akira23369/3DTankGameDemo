using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    // ����
    public CustomGUILabel labelScoreNum;
    // ʱ��
    public CustomGUILabel labelTime;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    // Ѫ��
    public CustomGUITexture texHpRel;
    // hpѪ��ͼ�Ŀ�
    public float hpW = 500;

    [HideInInspector]
    public int nowScore = 0;

    [HideInInspector]
    public float nowTime = 0;
    

    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            // ������ð�ť��
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            // ����˳���ť, ����ȷ�Ͽ�, ���ؿ�ʼ����
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
            labelTime.guiContent.text += $"{time / 3600}ʱ";
        }
        if (time % 3600 / 60 > 0 || time / 3600 > 0)
        {
            labelTime.guiContent.text += $"{time % 3600 / 60}��";
        }
        labelTime.guiContent.text += $"{time % 60}";
    }

    // ���½���
    public void AddScroe(int value)
    {
        nowScore += value;
        labelScoreNum.guiContent.text = nowScore.ToString();
    }
    public void UpdateHp(int maxHp, int hp) => texHpRel.guiPos.Width = (float)hp / maxHp * hpW;
}
