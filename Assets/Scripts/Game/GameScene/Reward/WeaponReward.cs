using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int r = Random.Range(0, weaponObj.Length);
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            playerObj.ChangeWeapon(weaponObj[r]);

            // 播放获取奖励的特效
            GameObject eff = Instantiate(getEff, transform.position, transform.rotation);
            AudioSource audio = eff.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.songValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSong;
            
            // 获取到自己后移除
            Destroy(this.gameObject);
        }
    }
}
