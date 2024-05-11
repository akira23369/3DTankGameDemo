using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr _instance = new GameDataMgr();
    public static GameDataMgr Instance => _instance;
    // �������Ϸ����
    public MusicData musicData;
    public RankList rankData;
    private GameDataMgr()
    {
        musicData = PlayerPrefsDataMgr.Instance.Load(typeof(MusicData), "Music") as MusicData;
        if (musicData.isFirst)
        {
            musicData.isFirst = false;
            musicData.isOpenMusic = true;
            musicData.isOpenSong = true;
            musicData.musicValue = 1;
            musicData.songValue = 1;
            PlayerPrefsDataMgr.Instance.Save(musicData, "Music");
        }
        rankData = PlayerPrefsDataMgr.Instance.Load(typeof(RankList), "Rank") as RankList;
    }

    // RankPanel�ײ�����
    public void AddRankInfo(string name, int sc, float time)
    {
        rankData.list.Add(new RankInfo(name, sc, time));
        // �ײ���������
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        // �ų�����
        for (int i = rankData.list.Count - 1; i >= 8; i--)
            rankData.list.RemoveAt(i);
        // �洢
        PlayerPrefsDataMgr.Instance.Save(rankData, "Rank");
    }

    public void OpenOrCloseSong(bool isopen)
    {
        musicData.isOpenSong = isopen;
        PlayerPrefsDataMgr.Instance.Save(musicData, "Music");
    }
    public void OpenOrCloseMusic(bool isopen)
    {
        musicData.isOpenMusic = isopen;
        PlayerPrefsDataMgr.Instance.Save(musicData, "Music");
        BKMusic.Instance.ChangeOpen(isopen);
    }
    public void ChangeSongValue(float value)
    {
        musicData.songValue = value;
        PlayerPrefsDataMgr.Instance.Save(musicData, "Music");
    }
    public void ChangeBKValue(float value)
    {
        musicData.musicValue = value;
        PlayerPrefsDataMgr.Instance.Save(musicData, "Music");
        BKMusic.Instance.ChangeValue(value);
    }
}
