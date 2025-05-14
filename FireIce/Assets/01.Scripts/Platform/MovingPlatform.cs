using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IObstacleActive, IFrozen
{
    [Header("이동 지점")]
    [SerializeField] private List<Transform> waypoints; // 멈추는 위치

    [Header("이동 설정")]
    [SerializeField] private float speed = 2f; // 속도
    [SerializeField] private float waitTime = 1f; // 기다리는 시간

    [field: SerializeField] public bool IsActive { get; set; } = false;

    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }


    private int currentIndex = 0; // 현재 인덱스
    private float waitCounter = 0f;

    private void Awake()
    {
        if (waypoints == null || waypoints.Count < 2)
            Debug.LogError($"{name}: waypoints에 최소 2개 이상의 Transform을 등록하세요.");

        // 시작 위치 세팅
        transform.position = waypoints[0].position;

        FrozenActive(IsFrozen);
    }

    private void Update()
    {
        if (IsFrozen) return;

        if (IsActive)
            Move();
    }

    public void IsActiveTrue()
    {
        IsActive = true;
    }

    public void IsActiveFalse()
    {
        IsActive = false;
    }

    private void Move()
    {
        if (waitCounter > 0f) // 도착시 기다리는 시간 계산
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        // 목표 웨이 포인트 지정
        Vector2 targetPos = waypoints[currentIndex].position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // 거의 도착하면 대기 후 다음 인덱스 계산
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            waitCounter = waitTime;
            currentIndex = (currentIndex + 1) % waypoints.Count;
        }
    }

    // 플레이어가 올라오면 플랫폼에 붙여서 흔들림 없이 따라다니게
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(col.transform.position.y > transform.position.y)
            col.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer != LayerMask.NameToLayer("Player")) return;

            col.transform.SetParent(null);

    }

    //private void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.collider.CompareTag("Player"))
    //    {
    //        // 0.01초 뒤에 부모 제거
    //        StartCoroutine(DelayedUnparent(col.transform));
    //    }
    //}

    //private IEnumerator DelayedUnparent(Transform target)
    //{
    //    yield return null; // 다음 프레임까지 대기
    //    target.SetParent(null);
    //}

    public void IsFrozenTrue()
    {
        IsFrozen = true;
        FrozenActive(IsFrozen);
    }

    public void IsFrozenFalse()
    {
        IsFrozen = false;
        FrozenActive(IsFrozen);
    }

    public void FrozenActive(bool isIce)
    {
        IceObj.SetActive(isIce);
    }

}