using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition attackPoint { get { return uiCondition.attackPoint; } }
    Condition exp { get { return uiCondition.Exp; } } 
    Condition level {  get { return uiCondition.Level; } } 
    Condition gold { get { return uiCondition.Gold; } }

    public void GetExpAndGold(float expAmount, float goldAmount)
    {
        exp.Add(expAmount);
        gold.Add(goldAmount);
    }

    public void LevelUp()
    {

    }

}
