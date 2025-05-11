using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FireAbility : MonoBehaviour, IAbility
{
    const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    const string poisonTag = "Poison Obstacle"; //독 Tag
    const string statefulTag = "Stateful Obstacle"; //형태변화가 있는 오브젝트
    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //부딪힌 상대의 태그 확인

        if (targetTag == fireTag) //장애물의 태그가 불일 경우
        {
            Debug.Log("불 캐릭터가 불 통과 중");
        }
        else if (targetTag == iceTag || targetTag == poisonTag) //장애물의 태그가 얼음일 경우
        {
            GameOver();
        }
        else if (targetTag == statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data)) //타겟(장애물)에 붙어있는 Switch를 찾음
            {
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(false)
            }
        }
    }

    void GameOver() //나연님 재시작 붙이기=============================================================
    {
        Debug.Log("게임 오버!");
    }
}



