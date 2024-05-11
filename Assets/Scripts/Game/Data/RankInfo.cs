using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankInfo
{
    public string name;
    public int score;
    public float time;

    // ���û�����Ĭ�ϵĹ��캯���Ļ�PlayerPrefs.Load��
    // Activator.CreateInstanceʹ��Ĭ�Ϲ��캯������ʵ��ʱ�Ļᱨ��
    public RankInfo() { }
    public RankInfo(string na, int sc, float tm)
    {
        name = na;
        score = sc;
        time = tm;
    }
}

public class RankList
{
    public List<RankInfo> list;
}
