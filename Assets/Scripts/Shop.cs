using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private float levelUpNeedGold = 10;
    private float playerLevel;

    public TextMeshProUGUI levelupGoldIndicator;

    private void OnEnable()
    {
        playerLevel = GameManager.Instance.Player.Condition.uiCondition.Level.curValue;
        CheckLevelUpNeedGold();

    }

    public void LevelUp()
    {
        if(levelUpNeedGold < GameManager.Instance.Player.Condition.uiCondition.Gold.curValue)
        {
            GameManager.Instance.Player.Condition.uiCondition.Gold.Subtract(levelUpNeedGold);
            GameManager.Instance.Player.Condition.uiCondition.Level.Add(1);
            playerLevel = GameManager.Instance.Player.Condition.uiCondition.Level.curValue;
            GameManager.Instance.Player.Condition.uiCondition.attackPoint.AtkUp();

        }
        CheckLevelUpNeedGold();

    }

    private void CheckLevelUpNeedGold()
    {
        if (playerLevel < 16)
        {
            levelUpNeedGold = Mathf.Floor((5 + playerLevel) * Mathf.Pow((float)1.07, playerLevel) - 1);
        }
        else
        {
            levelUpNeedGold = Mathf.Floor(20 * Mathf.Pow((float)1.07, playerLevel) - 1);
        }

        levelupGoldIndicator.text = levelUpNeedGold.ToString();
    }

}
