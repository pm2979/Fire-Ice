using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IceAbility : MonoBehaviour, IAbility
{
    public void Interact(GameObject target)
    {
        Debug.Log("얼음");
        string targetTag = target.tag; //부딪힌 상대의 태그 확인

        if (targetTag == ObstacleTags.iceTag) //장애물의 태그가 얼음일 경우
        {
            Debug.Log("얼음 캐릭터가 얼음 통과 중");
        }
        else if (targetTag == ObstacleTags.fireTag || targetTag == ObstacleTags.poisonTag) //장애물의 태그가 불일 경우
        {
            GameOver();
        }
        else if (targetTag == ObstacleTags.statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data))
            {
                Debug.Log("얼음과 스위치 충돌");
                data.IsFrozenTrue();
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(true)
            }
        }
    }
    void GameOver() //나연님 재시작 붙이기=============================================================
    {
        Debug.Log("게임 오버!");
    }
}
