using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    //시간제한을 두는 것이 아닌 경과시간을 체크합니다.
    //스테이지별 시간 정해야 함 - Find로 map을 찾고 그 map에 설정된 시간 값을 받기
    //정해진 시간내에 클리어가 되었는지 안되었는지 체크

    public bool isTimeExceeded { get; private set; } 
    
    //실시간 타이머
    public float elapsedTime {  get; private set; }

    //목표 시간
    public int curtimeLimit { get; private set; }
    void Awake()
    {
        // 씬에 배치된 Map 컴포넌트를 찾아서 timeConfig 읽어오기
        var map = FindObjectOfType<Map>();
        if (map != null && map.timeConfig != null)
        {
            curtimeLimit = map.timeConfig.TotalTime;
        }
        else
        {
            Debug.LogWarning("Map 또는 TimeConfig를 찾을 수 없습니다.");
        }
    }
    void Update()
    {
        // 경과시간 누적
        elapsedTime += Time.deltaTime;

        // 제한시간 초과 판정
        // 제한시간보다 경과시간이 크면 초과로 판단
        if (elapsedTime > curtimeLimit)
        {
            isTimeExceeded = true;
        }
    }
}
