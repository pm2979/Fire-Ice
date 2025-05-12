using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OpenWall : MonoBehaviour, IObstacleActive
{
    [SerializeField] private float zAngle = 90f; // 최대 회전 각도
    [SerializeField] private float speed = 5; // 속도

    [field: SerializeField] public bool IsActive { get; set; } = false;

    public void IsActiveTrue()
    {
        IsActive = true;
    }

    public void IsActiveFalse()
    {
        IsActive = false;
    }

    private void Update()
    {

        if (IsActive == true) // 최도 90도까지 회전
        {
            Quaternion current = transform.rotation;
            Quaternion target = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.Lerp(current, target, speed * Time.deltaTime);
        }
        else // 다시 원래 위치로 회전
        {
            Quaternion current = transform.rotation;
            Quaternion target = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(current, target, speed * Time.deltaTime);
        }
    }
}
