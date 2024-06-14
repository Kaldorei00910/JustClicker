using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public Image uiBar;
    public TextMeshProUGUI Txt;

    private void Start()
    {
        curValue = startValue;
    }

    private float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        curValue += value;
        UiUpdate();
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
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
