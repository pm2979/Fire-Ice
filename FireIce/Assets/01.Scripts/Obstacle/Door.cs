using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;


public class Door : MonoBehaviour, ISwitchActive
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private GameObject doorObj;
    [SerializeField] private float speed = 5;

    private bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }

    

    private void Update()
    {

        if(IsActive == true)
        {
            doorObj.transform.position = Vector3.MoveTowards(doorObj.transform.position, targetPos.position, Time.deltaTime * speed);
        }
        else
        {
            doorObj.transform.position = Vector3.MoveTowards(doorObj.transform.position, transform.position, Time.deltaTime * speed);
        }
    }

}
