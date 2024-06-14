using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image uiBar;

    float maxHp = 2;
    float hp = 2;
    float exp = 4;
    float level = 1;
    float gold = 2;

    public void Attacked()
    {
        Debug.Log("���ݹ���");
        hp-=(GameManager.Instance.Player.Condition.uiCondition.attackPoint.curValue);

        if(hp < 0)
        {
            Dead();
        }
        UiUpdate();
    }

    public void Dead()
    {
        GameManager.Instance.Player.Condition.GetExpAndGold(exp,gold);
        level+=1;

        //TODO : �̹��� ����
        hp = 10 * (level - 1 + Mathf.Pow((float)1.55, level - 1));//Ŭ��Ŀ ������� ���� �̿�
        //https://clickerheroes.fandom.com/wiki/Formulas#Monster_HP_for_levels
        maxHp = hp;

        gold += level*2;
    }

    public void UiUpdate()
    {
        uiBar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return hp / maxHp;
    }
}
