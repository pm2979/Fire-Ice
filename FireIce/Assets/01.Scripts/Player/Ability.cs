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
    protected IFrozen frozenTarget = null; //플레이어와 충돌한 오브젝트가 IFrozen을 가지고 있을 때 충돌한 오브젝트를 저장할 변수

    private void Update()
    {
        if (InputKeyAbility() && frozenTarget != null) //아래 키를 입력받고 frozenTarget이 있다면,
        {
            Interact((frozenTarget as MonoBehaviour).gameObject); //Interart()에 frozenTarget을 전달
        }
    }

    protected abstract bool InputKeyAbility(); //아래 키 입력받는 메서드

    public virtual void Interact(GameObject target) //상호작용(플레이어-오브젝트)
    {
        string targetTag = target.tag; //태그를 가져와서,

        if (target.TryGetComponent<IFrozen>(out var data)) //IFrozen을 가지고 있는지 확인
        {
            HandleIFrozen(data);
        }
        else if(targetTag == ObstacleTags.poisonTag) //독에 빠지면 게임오버
        {
            GameOver();
        }
        else if(targetTag == ObstacleTags.iceTag) //얼음과 부딪히면,
        {
            InIcePool();
        }
        else if(targetTag == ObstacleTags.fireTag) //불과 부딪히면,
        {
            InFirePool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //충돌이 시작될 때 실행
    {
        HandleCollisionEnter(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) //충돌이 시작될 때 실행
    {
        HandleCollisionEnter(collision.collider.gameObject);
    }

    private void HandleCollisionEnter(GameObject collidedObject)
    {
        if (collidedObject.TryGetComponent<IFrozen>(out var frozen)) //충돌한 오브젝트에서 frozen을 찾음
        {
            frozenTarget = frozen; //frozenTarget에 저장
        }
        else
        {
            Interact(collidedObject); //Interact로 처리
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //충돌이 끝날 때 실행
    {
         HandlecollisionExit(collision.gameObject);        
    }

    private void OnCollisionExit2D(Collision2D collision) //충돌이 끝날 때 실행
    {
         HandlecollisionExit(collision.gameObject);
    }

    private void HandlecollisionExit(GameObject exitedObject)
    {
        if(exitedObject.TryGetComponent<IFrozen>(out var frozen) && frozen == frozenTarget) // //충돌이 끝난 오브젝트가 frozenTarget이면
        {
            frozenTarget = null; //null로 초기화
        }
    }

    public void GameOver()
    {
        Debug.Log("게임 오버!");
    }
    protected virtual void HandleIFrozen(IFrozen frozen)
    {
        //스위치 얼림/녹임 처리 | 자식 클래스에서 정의
    }
    protected virtual void InFirePool()
    {
        // 플레이어에 따라 게임 오버 or Debug.Log | 자식 클래스에서 정의
    }
    protected virtual void InIcePool()
    {
        // 플레이어에 따라 게임 오버 or Debug.Log | 자식 클래스에서 정의
    }
}

public class ObstacleTags
{
    public const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    public const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    public const string poisonTag = "Poison Obstacle"; //독 Tag
}

