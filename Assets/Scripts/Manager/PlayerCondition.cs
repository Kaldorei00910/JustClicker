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

        if(exp.curValue > exp.maxValue)
        {
            //���� �������� ǥ���ϱ�
        }
    }

    public void LevelUp()
    {
        //���� ����� ���� ����
        exp.curValue = 0;
        level.Add(1);
        if(level.curValue < 16) 
        {
            Mathf.Floor((5 + level.curValue) * Mathf.Pow((float)1.07, level.curValue) - 1);
        }
        else
        {
            Mathf.Floor(20 * Mathf.Pow((float)1.07, level.curValue) - 1);
        }
    }

}
