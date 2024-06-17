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
            Txt.text = curValue.ToString();
        }
    }

    public void AtkUp()
    {
        curValue = curValue * 4;
        UiUpdate();
    }
}
