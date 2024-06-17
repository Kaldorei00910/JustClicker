using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition attackPoint;
    public Condition Level;
    public Condition Gold;
    public Condition Hp;
    public Condition AutoAtkTime;

    private void Start()
    {
        GameManager.Instance.Player.Condition.uiCondition = this;
    }
}
