using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;

    // 发射位置
    public Transform[] shootPos;

    // 武器拥有者
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
            // 创建子弹游戏对象
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            // 设置子弹的拥有者
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.FatherObj = this.FatherObj;
        }
    }
}
