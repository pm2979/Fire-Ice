using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IceAbility : MonoBehaviour, IAbility
{
    const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    const string poisonTag = "Poison Obstacle"; //독 Tag
    const string statefulTag = "Stateful Obstacle"; //형태변화가 있는 오브젝트

    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //부딪힌 상대의 태그 확인

        if (targetTag == iceTag) //장애물의 태그가 얼음일 경우
        {
            Debug.Log("물 캐릭터가 얼음 통과 중");
        }
        else if (targetTag == fireTag || targetTag == poisonTag) //장애물의 태그가 불일 경우
        {
            GameOver();
        }
        else if (targetTag == statefulTag)
        {
            if (target.TryGetComponent<Switch>(out var data))
            {
                //data.SetFrozen(abilityType == ABILITYTYPE.ICE); //SetFrozen(true)
            }
        }
    }
    void GameOver() //나연님 재시작 붙이기=============================================================
    {
        Debug.Log("게임 오버!");
    }
}
