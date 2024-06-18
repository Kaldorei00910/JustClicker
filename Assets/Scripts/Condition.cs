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
    private string GetBigIntegerText(BigInteger value)//������ ��� �����ִ� �Լ�
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
            returnStr = numList[i] + BigIntegerUnitArr[i];//�ݺ����� ���� �ʿ�� ����, ���ֹ迭�� �Ѿ�� �����߻�,
            //�� �ڵ� �������� + returnStr�� �Ͽ� 123M456K789 ó�� ǥ�� ����
        }
        return returnStr;
    }


    public void AtkUp()
    {
        curValue = curValue * 4;
        UiUpdate();
    }
}
