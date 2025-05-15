using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IObstacleActive, IFrozen
{
    [Header("�̵� ����")]
    [SerializeField] private List<Transform> waypoints; // ���ߴ� ��ġ

    [Header("�̵� ����")]
    [SerializeField] private float speed = 2f; // �ӵ�
    [SerializeField] private float waitTime = 1f; // ��ٸ��� �ð�

    [field: SerializeField] public bool IsActive { get; set; } = false;

    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }


    private int currentIndex = 0; // ���� �ε���
    private float waitCounter = 0f;

    private void Awake()
    {
        if (waypoints == null || waypoints.Count < 2)
            Debug.LogError($"{name}: waypoints�� �ּ� 2�� �̻��� Transform�� ����ϼ���.");

        // ���� ��ġ ����
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
        if (waitCounter > 0f) // ������ ��ٸ��� �ð� ���
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        // ��ǥ ���� ����Ʈ ����
        Vector2 targetPos = waypoints[currentIndex].position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // ���� �����ϸ� ��� �� ���� �ε��� ���
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            waitCounter = waitTime;
            currentIndex = (currentIndex + 1) % waypoints.Count;
        }
    }

    // �÷��̾ �ö���� �÷����� �ٿ��� ��鸲 ���� ����ٴϰ�
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
    //        // 0.01�� �ڿ� �θ� ����
    //        StartCoroutine(DelayedUnparent(col.transform));
    //    }
    //}

    //private IEnumerator DelayedUnparent(Transform target)
    //{
    //    yield return null; // ���� �����ӱ��� ���
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