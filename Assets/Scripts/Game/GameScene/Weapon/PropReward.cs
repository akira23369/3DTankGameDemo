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

    // ��ȡ�󲥷ŵ���Ч
    public GameObject eff;

    private void OnTriggerEnter(Collider other)
    {
        // ֻ����Ҳ������Խ���
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
                    // ����Ѫ��
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
            // ������Ч
            GameObject tmp = Instantiate(eff, transform.position, transform.rotation);
            AudioSource audio = tmp.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.songValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSong;
        }
        Destroy(this.gameObject);
    }
}