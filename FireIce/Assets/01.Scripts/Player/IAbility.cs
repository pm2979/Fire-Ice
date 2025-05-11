using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public interface IAbility
{
    void Interact(GameObject target);
}

public static class ObstacleTags
{
    public const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    public const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    public const string poisonTag = "Poison Obstacle"; //독 Tag
    public const string statefulTag = "Stateful Obstacle"; //형태변화가 있는 오브젝트
}