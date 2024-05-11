using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;
    private List<CustomGUILabel> labPM = new List<CustomGUILabel>();
    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    void Start()
    {
        for (int i = 0; i < this.transform.Find("Name").childCount; i++)
        {
            labPM.Add(this.transform.Find($"PM/LabelPM ({i + 1})").GetComponent<CustomGUILabel>());
            labName.Add(this.transform.Find($"Name/LabelName ({i + 1})").GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find($"Score/LabelScore ({i + 1})").GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find($"Time/LabelTime ({i + 1})").GetComponent<CustomGUILabel>());
        }

        // �����¼�����
        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        HideMe();
    }

    // ������
    public void UpdateInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            labName[i].guiContent.text = list[i].name;
            labScore[i].guiContent.text = list[i].score.ToString();
            // Time��s  ת��Ϊh, m, s
            int time = (int)list[i].time;
            labTime[i].guiContent.text = "";
            if (time / 3600 > 0)
            {
                labTime[i].guiContent.text += $"{time / 3600}ʱ";
            }
            if (time % 3600 / 60 > 0 || labTime[i].guiContent.text != "")
            {
                labTime[i].guiContent.text += $"{time % 3600 / 60}��";
            }
            labTime[i].guiContent.text += $"{time % 60}��";
        }
    }
    // ��ʾ����ʱ������������
    public override void ShowMe()
    {
        base.ShowMe();
        UpdateInfo();
    }
}
