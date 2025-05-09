using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OpenWall : MonoBehaviour, IObstacleActive
{
    [SerializeField] private float zAngle = 90f;
    [SerializeField] private float speed = 5;

    private bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }

    private void Update()
    {

        if (IsActive == true)
        {
            Quaternion current = transform.rotation;
            Quaternion target = Quaternion.Euler(0f, 0f, zAngle);
            transform.rotation = Quaternion.Lerp(current, target, speed * Time.deltaTime);
        }
        else
        {
            Quaternion current = transform.rotation;
            Quaternion target = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(current, target, speed * Time.deltaTime);
        }
    }
}
