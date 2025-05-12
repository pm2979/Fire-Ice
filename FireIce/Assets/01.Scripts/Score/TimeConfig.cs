using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "TimeSetting")]
public class TimeConfig : ScriptableObject
{
    //제한시간을 넘기면 게임이 끝나는 것이 아닌 그저 등급 측정을 위한 값입니다.
    [Header("제한 시간")]
    public int limitMin = 0;
    public int linitSec = 0;

    public int TotalTime =>limitMin * 60 + linitSec;
}
