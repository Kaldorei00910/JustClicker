using UnityEngine;

public class AllStats : MonoBehaviour
{
    public PlayerStat AutoAtkTime;

    //이외에 추가할 스탯들 추가
    private void Start()
    {
        GameManager.Instance.Player.Condition.allStats = this;
    }


}