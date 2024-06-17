using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    public AllStats allStats;
    Condition attackPoint { get { return uiCondition.attackPoint; } }
    Condition level {  get { return uiCondition.Level; } } 
    Condition gold { get { return uiCondition.Gold; } }    
    PlayerStat autoAtkTime { get { return allStats.AutoAtkTime; } }
}
