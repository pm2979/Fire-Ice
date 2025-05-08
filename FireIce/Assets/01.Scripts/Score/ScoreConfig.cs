using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Coin")]
public class ScoreConfig : ScriptableObject
{
    //각자 타입
    [Header("타입")]
    public COINTYPE coinType;
    //각자 점수
    [Header("고유 점수")]
    public float coinScore;
}
