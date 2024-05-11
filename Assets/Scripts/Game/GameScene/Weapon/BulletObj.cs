using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;

    public TankBaseObj _fatherObj;
    public TankBaseObj FatherObj
    {
        get => _fatherObj;
        set => _fatherObj = value;
    }

    // 子弹销毁特效
    public GameObject effObj;

    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || 
            other.CompareTag("Player") && _fatherObj.CompareTag("Monster") || 
            other.CompareTag("Monster") && _fatherObj.CompareTag("Player"))
        {
            // 如果碰撞到的对象时Tank, 就要计算受伤
            TankBaseObj tank = other.GetComponent<TankBaseObj>();
            tank?.Wound(_fatherObj);

            // 子弹销毁时创建一个特效
            if (effObj != null)
            {
                GameObject eff = Instantiate(effObj, transform.position, transform.rotation);
                // 创建完特效后设置音量大小
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.songValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSong;
            }
            Destroy(this.gameObject);
        }
    }
}
