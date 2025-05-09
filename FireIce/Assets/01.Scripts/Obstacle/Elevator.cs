using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IObstacleActive
{
    
    [SerializeField] private bool isActive = false;
    public bool IsActive { get => isActive; set => isActive = value; }

}
