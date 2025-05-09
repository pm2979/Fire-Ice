using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;


public class Door : MonoBehaviour, IObstacleActive
{
    [SerializeField] private Transform targetPos; // 목표 위치
    [SerializeField] private GameObject doorObj; // 이동할 오브젝트
    [SerializeField] private float speed = 5; // 속도

    private bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }

    

    private void Update()
    {

        if(IsActive == true) // 문 traget으로 이동
        {
            doorObj.transform.position = Vector3.MoveTowards(doorObj.transform.position, targetPos.position, Time.deltaTime * speed);
        }
        else // 문 원래 자리도 이동
        {
            doorObj.transform.position = Vector3.MoveTowards(doorObj.transform.position, transform.position, Time.deltaTime * speed);
        }
    }

}
