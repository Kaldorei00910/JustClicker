using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMonsterSO", menuName = "JustClicker/Monster", order = 0)]
public class MonsterSO : ScriptableObject
{
    [Header("Monster Setting")]
    public float Hp;
    public float Exp;

}
