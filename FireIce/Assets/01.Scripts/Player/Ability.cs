using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("충돌 중");
        Interact(other.gameObject);
    }

    public ABILITYTYPE abilityType;

    const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    const string poisonTag = "Poison Obstacle"; //독 Tag
    const string statefulTag = "Stateful Obstacle"; //형태변화가 있는 오브젝트

    //public GameObject statefulObstacle;
    //Dictionary<string, Action> tagActions;

    public void Interact(GameObject target)
    {
        string targetTag = target.tag; //부딪힌 상대의 태그 확인

        switch (abilityType)
        {
            case ABILITYTYPE.FIRE: //플레이어가 FIRE 능력을 가지고 있다면,

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
                    var csSwitch = target.GetComponent<Switch>(); //타겟(장애물)에 붙어있는 Switch를 찾음
                    if(csSwitch != null)
                    {
                        //녹임
                        if (csSwitch.isFrozen)
                        {
                            //얼음 끄기
                            csSwitch.isFrozen = false;
                        }
                        else
                        {

                        }
                    }
                }
                break;

            case ABILITYTYPE.ICE: //플레이어가 ICE 능력을 가지고 있다면,

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
                    var csSwitch = target.GetComponent<Switch>();
                    if(csSwitch != null)
                    {
                        //얼림
                        if(!csSwitch.isFrozen)
                        {
                            //얼음 켜기
                            csSwitch.isFrozen = true;
                            Debug.Log("얼음 충돌");
                        }
                        else
                        {

                        }
                    }
                }
                break;
        }
    }

    void GameOver() //나연님 재시작 붙이기=============================================================
    {
        Debug.Log("게임 오버!");
    }
}