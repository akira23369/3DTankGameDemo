using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;

    // ����λ��
    public Transform[] shootPos;

    // ����ӵ����
    public TankBaseObj fatherObj;
    public TankBaseObj FatherObj
    {
        get => fatherObj;
        set => fatherObj = value;
    }

    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            // �����ӵ���Ϸ����
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            // �����ӵ���ӵ����
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.FatherObj = this.FatherObj;
        }
    }
}
