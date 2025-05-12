using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false;

    [Header("이동 지점")]
    [SerializeField] private List<Transform> waypoints; // 멈추는 위치

    private void Update()
    {
        if (IsActive)
            Move();
    }

    private void Move()
    {
        
    }
}
