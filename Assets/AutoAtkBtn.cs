using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoAtkBtn : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image fillImage;
    bool isAutoOn = false;

    private void Update()
    {
        if(isAutoOn)
        {
            fillImage.fillAmount += Time.deltaTime / (float)GameManager.Instance.Player.Condition.allStats.AutoAtkTime.curValue;
            if(fillImage.fillAmount >= 1)
            {
                fillImage.fillAmount = 0;
            }
        }
    }

    public void AutoBtnActiveTxt()
    {
        if (!isAutoOn)
        {
            fillImage.fillAmount = 0;
            text.text = "자동클릭 on";
            isAutoOn = true ;
        }
        else
        {
            fillImage.fillAmount = 0;
            text.text = "자동클릭 off";
            isAutoOn= false ;
        }
    }
}
