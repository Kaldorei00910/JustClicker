using UnityEngine;

public class AllStats : MonoBehaviour
{
    public PlayerStat AutoAtkTime;

    //�̿ܿ� �߰��� ���ȵ� �߰�
    private void Start()
    {
        GameManager.Instance.Player.Condition.allStats = this;
    }


}