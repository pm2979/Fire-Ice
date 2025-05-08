using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum AbilityType //나중에 나연님 Enum으로 빼기!=====================================
{
    FIRE,
    ICE
}

public class Ability : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌 중");
        Interact(other.gameObject);
    }

    public AbilityType abilityType;

    const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    const string poisonTag = "Poison Obstacle"; //독 Tag
    const string statefulTag = "Stateful Obstacle"; //형태변화가 있는 오브젝트

    public GameObject statefulObstacle;

    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //부딪힌 상대의 태그 확인

        switch (abilityType)
        {
            case AbilityType.FIRE: //플레이어가 FIRE 능력을 가지고 있다면,

                if (targetTag == fireTag) //장애물의 태그가 불일 경우
                {
                    Debug.Log("불 캐릭터가 불 통과 중");
                }
                else if (targetTag == iceTag) //장애물의 태그가 얼음일 경우
                {
                    GameOver();
                }
                else if (targetTag == poisonTag) //장애물의 태그가 독일 경우
                {
                    GameOver();
                }
                else if (targetTag == statefulTag)
                {
                    //녹임
                    //IceObstacle.Melt();
                }
                break;

            case AbilityType.ICE: //플레이어가 ICE 능력을 가지고 있다면,

                if (targetTag == iceTag) //장애물의 태그가 얼음일 경우
                {
                    Debug.Log("물 캐릭터가 얼음 통과 중");
                }
                else if (targetTag == fireTag) //장애물의 태그가 불일 경우
                {
                    GameOver();
                }
                else if (targetTag == poisonTag)
                {
                    GameOver();
                }
                else if (targetTag == statefulTag)
                {
                    //얼림
                    //IceObstacle.Freeze();
                }
                break;
        }
    }

    void GameOver() //나연님 재시작이랑 연결?
    {
        Debug.Log("게임 오버!");
    }

}