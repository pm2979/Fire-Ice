using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UIElements;


public abstract class Ability : MonoBehaviour
{
    protected IFrozen frozenTarget = null;

    private void Update()
    {
        // 아래 키
        if (InputKeyAbility() && frozenTarget != null)
        {
            Interact((frozenTarget as MonoBehaviour).gameObject); //==============================
        }
    }

    protected abstract bool InputKeyAbility();

    public virtual void Interact(GameObject target)
    {
        string targetTag = target.tag;

        if (target.TryGetComponent<IFrozen>(out var data))
        {
            HandleIFrozen(data);
        }
        else if(targetTag == ObstacleTags.poisonTag)
        {
            GameOver();
        }
        else if(targetTag == ObstacleTags.iceTag)
        {
            InIcePool();
        }
        else if(targetTag == ObstacleTags.fireTag)
        {
            InFirePool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.collider.gameObject;

        IFrozen frozen = collision.collider.GetComponent<IFrozen>();
        if (frozen != null)
        {
            frozenTarget = frozen;
        }
        else
        {
            Interact(collidedObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IFrozen frozen = collision.collider.GetComponent<IFrozen>();
        if (frozen != null && frozen == frozenTarget)
        {
            frozenTarget = null;
        }
    }

    public void GameOver() //나연님 재시작 붙이기=============================================================
    {
        Debug.Log("게임 오버!");
    }
    protected virtual void HandleIFrozen(IFrozen frozen)
    {

    }
    protected virtual void InFirePool()
    {

    }
    protected virtual void InIcePool()
    {

    }
}

public class ObstacleTags
{
    public const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    public const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    public const string poisonTag = "Poison Obstacle"; //독 Tag
    public const string statefulTag = "Stateful Obstacle"; //형태변화가 있는 오브젝트
}

