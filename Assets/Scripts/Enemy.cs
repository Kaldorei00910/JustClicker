using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum AttackWay
{
    MOUSEHIT,
    AUTOHIT
}

public class Enemy : MonoBehaviour
{
    public Image uiBar;
    public TextMeshProUGUI levelTxt;

    public SpriteRenderer monsterSprite;
    public List<Sprite> Monsters;
    public Transform ParticleSummonPoint;

    BigInteger maxHp = 2;
    BigInteger hp = 2;
    float level = 1;
    BigInteger gold = 2;

    bool isAutoOn = false;



    private void OnMouseDown()
    {
        Attacked(AttackWay.MOUSEHIT);
        
    }

    public void Attacked(AttackWay atkway)
    {
        hp -= (GameManager.Instance.Player.Condition.uiCondition.attackPoint.curValue);
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool("Effect");
        if (atkway == AttackWay.MOUSEHIT)
        {
            obj.transform.position = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        else
        {
            obj.transform.position = ParticleSummonPoint.position;
        }

        if (hp < 0)
        {
            Dead();
        }

        UiUpdate();
    }

    public void Dead()
    {
        GameManager.Instance.Player.Condition.uiCondition.Gold.Add((BigInteger)gold);

        level+=1;
        monsterSprite.sprite = Monsters[UnityEngine.Random.Range(0, 4)];
        hp = (BigInteger)(10 * (level - 1 + Mathf.Pow((float)1.55, level - 1)));//클리커 히어로즈 공식 이용
        //https://clickerheroes.fandom.com/wiki/Formulas#Monster_HP_for_levels
        maxHp = (BigInteger)hp;

        gold = gold + (hp / 15);//TODO : 드랍 골드량 수정하기
    }

    public void UiUpdate()
    {
        uiBar.fillAmount = GetPercentage();
        levelTxt.text = "LV. "+ level;
    }

    private float GetPercentage()
    {
        return ((float)hp / (float)maxHp);
    }

    IEnumerator AutoAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(GameManager.Instance.Player.Condition.allStats.AutoAtkTime.curValue);
            Attacked(AttackWay.AUTOHIT);
        }
    }

    public void AutoAtkBtnActivated()
    {
        if(!isAutoOn)
        {
            StartCoroutine(AutoAttack());
            isAutoOn = true;
        }
        else
        {
            StopAllCoroutines();
            isAutoOn= false;
        }
        
    }



}
