using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition attackPoint;
    public Condition Level;
    public Condition Gold;


    private void Start()
    {
        GameManager.Instance.Player.Condition.uiCondition = this;
    }
}
