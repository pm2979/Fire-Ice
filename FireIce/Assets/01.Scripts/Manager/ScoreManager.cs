using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("테스트 모드: 체크하면 즉시 등급 계산")]
    public bool GodMode = false;
    // 한 스테이지당 한 번만 랭크 계산하도록
    private bool hasRank = false;


    //이벤트 구독 방식 사용
    public static event Action<COINTYPE> OnCoinType;

    [Space(5)]
    [Header("스크립트 참조")]
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] TimeTracker timeTracker;

    int fireTotal, iceTotal;
    int fireCollected = 0, iceCollected = 0;


    private void Awake()
    {
        // 씬에 있는 모든 Coin 오브젝트를 찾아서 총 목표치 계산
        var allCoins = FindObjectsOfType<Coin>();
        fireTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.FIRESTAR);
        iceTotal = allCoins.Count(c => c.scoreConfig.coinType == COINTYPE.ICESTAR);

        //게임 시작 초기 UI 호출
        scoreUI.InitializeTotals(fireTotal, iceTotal);
    }

    private void OnEnable()
    {
        OnCoinType += CoinTypeCollected;
    }

    private void OnDisable()
    {
        OnCoinType -= CoinTypeCollected;
    }
    void Update()
    {
        // 매 프레임 타이머 UI 갱신
        scoreUI.UpdateTimer(timeTracker.elapsedTime);

        // GodMode 테스트용: 한번만 랭크 평가
        if (GodMode && !hasRank)
        {
            Rank();
            hasRank = true;
        }
    }
    // Coin.cs 에서 호출
    public static void AddCoin(COINTYPE type)
    {
        OnCoinType?.Invoke(type);
    }

    // 실제 획득된 별 타입별 개수 관리 및 UI 갱신
    private void CoinTypeCollected(COINTYPE type)
    {
        switch (type)
        {
            case COINTYPE.FIRESTAR: fireCollected++; break;
            case COINTYPE.ICESTAR: iceCollected++; break;
            default: break;
        }
        scoreUI.UpdateCoinUI(fireCollected, iceCollected);
    }

    // 스테이지 종료 시 호출해서 등급을 계산. 현재는 GodMode에서 확인가능
    //A랭크 : 정해진 시간 안에 클리어 + 모든 코인 수집
    //B랭크 : 정해진 시간 안에 클리어 + 코인 미달 / 시간 초과 클리어 + 모든 코인 수집
    //C랭크 : 시간 초과 클리어 + 코인 미달
    public void Rank()
    {
        //제한 시간을 넘기지 않으면 false로 넘어옴. !가 붙었으므로 true임
        bool withinTime = !timeTracker.isTimeExceeded;
        //모든 파이어스타 먹으면 true
        bool allFire = fireCollected == fireTotal;
        //모든 아이스스타 먹으면 true
        bool allIce = iceCollected == iceTotal;

        GRADE result;
        if (withinTime && allFire && allIce)
        {
            result = GRADE.A;
        }
        else if ((withinTime && (!allFire || !allIce))
              || (!withinTime && allFire && allIce))
        {
            result = GRADE.B;
        }
        else result = GRADE.C;

        scoreUI.DisplayGrade(result);
        Debug.Log($"최종 등급: {result}");
    }
}
