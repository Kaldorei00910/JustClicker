using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition attackPoint;
    public Condition Exp;
    public Condition Level;

    private void Start()
    {
        GameManager.Instance.Player.Condition.uiCondition = this;
    }
}