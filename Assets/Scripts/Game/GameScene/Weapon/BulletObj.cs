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

    // �ӵ�������Ч
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
            // �����ײ���Ķ���ʱTank, ��Ҫ��������
            TankBaseObj tank = other.GetComponent<TankBaseObj>();
            tank?.Wound(_fatherObj);

            // �ӵ�����ʱ����һ����Ч
            if (effObj != null)
            {
                GameObject eff = Instantiate(effObj, transform.position, transform.rotation);
                // ��������Ч������������С
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.songValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSong;
            }
            Destroy(this.gameObject);
        }
    }
}
