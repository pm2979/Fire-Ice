using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    private IFrozen frozenTarget = null;
    [SerializeField] private MonoBehaviour abilityComponent;
    private IAbility ability;

    private void Awake()
    {
        ability = abilityComponent as IAbility;
    }

    private void Update()
    {
        // 아래 키
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && frozenTarget != null)
        {
            //frozenTarget.IsFrozenTrue();
            ability?.Interact((frozenTarget as MonoBehaviour).gameObject);
            Debug.Log("is Frozing");
        }
    }

    public void Interact(GameObject target)
    {
        Debug.Log("파이어");
        string targetTag = target.tag; //부딪힌 상대의 태그 확인

        if (targetTag == ObstacleTags.fireTag) //장애물의 태그가 불일 경우
        {
            Debug.Log("불 캐릭터가 불 통과 중");
        }
        else if (targetTag == ObstacleTags.iceTag || targetTag == ObstacleTags.poisonTag) //장애물의 태그가 얼음일 경우
        {
            GameOver();
        }
        else if (targetTag == ObstacleTags.statefulTag)
        {
            if (target.TryGetComponent<IFrozen>(out var data)) //타겟(장애물)에 붙어있는 Switch를 찾음
            {
                Debug.Log("불과 스위치 충돌");
                data.IsFrozenFalse();
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(false)
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IFrozen frozen = collision.collider.GetComponent<IFrozen>();
        if (frozen != null)
        {
            frozenTarget = frozen;
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

    void GameOver() //나연님 재시작 붙이기=============================================================
    {
        Debug.Log("게임 오버!");
    }
}



