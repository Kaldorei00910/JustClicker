using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public BigInteger curValue;
    public float startValue;
    public BigInteger maxValue;
    public Image uiBar;
    public TextMeshProUGUI Txt;

    private string[] BigIntegerUnitArr = new string[] {"","K","M","B","Qa","Qi","Sx","Sp","O","N","D","Ud","Dd","Td","Qad","Qid","Sxd"};

    private void Start()
    {
        curValue = (BigInteger)startValue;
    }

    private float GetPercentage()
    {
        return (float)(curValue / maxValue);
    }

    public void Add(BigInteger value)
    {
        curValue = BigInteger.Add(curValue, value);
        UiUpdate();
    }

    public void Subtract(BigInteger value)
    {
        curValue = (BigInteger)Mathf.Max((float)BigInteger.Subtract(curValue,value), 0);
        UiUpdate();
    }

    private void UiUpdate()
    {
        if (uiBar != null)
        {
            uiBar.fillAmount = GetPercentage();
        }

        if (Txt != null)
        {
            Txt.text = GetBigIntegerText(curValue);
        }
    }
    private string GetBigIntegerText(BigInteger value)//단위로 끊어서 보여주는 함수
    {
        int placeN = 3;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN);

        do
        {
            numList.Add((int)(value % p));
            value /= p;
        }
        while (value >= 1);
        string returnStr = "";
        for(int i = 0;i < numList.Count; i++)
        {
            returnStr = numList[i] + BigIntegerUnitArr[i];//반복문을 돌릴 필요는 없음, 유닛배열을 넘어가면 오류발생,
            //위 코드 마지막에 + returnStr을 하여 123M456K789 처럼 표시 가능
        }
        return returnStr;
    }


    public void AtkUp()
    {
        curValue = curValue * 4;
        UiUpdate();
    }
}
