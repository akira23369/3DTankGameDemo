using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankInfo
{
    public string name;
    public int score;
    public float time;

    // 如果没有这个默认的构造函数的话PlayerPrefs.Load中
    // Activator.CreateInstance使用默认构造函数创建实例时的会报错
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
