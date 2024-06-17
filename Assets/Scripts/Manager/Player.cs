using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCondition Condition;
    private void Awake()
    {
        GameManager.Instance.Player = this;
        Condition = GetComponent<PlayerCondition>();
    }
}
