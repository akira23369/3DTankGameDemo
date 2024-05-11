using UnityEngine;


public enum E_PropType
{
    Atk,
    Hp,
    MaxHp,
    Def,
}

public class PropReward : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;
    public int changeValue = 2;

    // 获取后播放的特效
    public GameObject eff;

    private void OnTriggerEnter(Collider other)
    {
        // 只有玩家才能属性奖励
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.Hp:
                    player.hp += changeValue;
                    if (player.hp >= player.maxHp) player.hp = player.maxHp;
                    // 更新血条
                    GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                    break;
                case E_PropType.MaxHp:
                    player.maxHp += changeValue;
                    GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                    break;
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
            }
            // 创建特效
            GameObject tmp = Instantiate(eff, transform.position, transform.rotation);
            AudioSource audio = tmp.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.songValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSong;
        }
        Destroy(this.gameObject);
    }
}