using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public enum AbilityType //나중에 나연님 Enum으로 빼기!=====================================
{
    FIRE,
    ICE
}

public class Ability : MonoBehaviour
{
    public AbilityType abilityType;

    //태그 바꾸기======================================================
    const string fireTag = "Fire Obstacle"; //불 Tag
    const string waterTag = "Water Obstacle"; //물 Tag
    const string iceTag = "Ice Obstacle"; //얼음 Tag
    const string iceToWayerTag = "IceToWater"; //얼음에서 물로 바뀌는 Tag

    public void Interact()
    {
        switch (abilityType)
        {
            case AbilityType.FIRE: //플레이어가 FIRE 능력을 가지고 있다면,

                if (tag == fireTag) //장애물의 태그가 불일 경우
                {
                    //1. 불 장애물을 통과한다.
                    Debug.Log("불 캐릭터가 불 통과 중");
                }
                else if (tag == iceTag) //장애물의 태그가 얼음일 경우
                {
                    //2. 얼음을 녹인다.
                    //IceObstacle.cs의 Melt() 가져오기
                    
                }
                else if (tag == waterTag) //장애물의 태그가 물일 경우
                {
                    GameOver();
                }
                break;

            case AbilityType.ICE: //플레이어가 ICE 능력을 가지고 있다면,

                if(tag == waterTag) //장애물의 태그가 물일 경우
                {
                    //1. 물 장애물을 통과한다.
                    Debug.Log("물 캐릭터가 물 통과 중");
                }
                else if(tag == iceTag) //장애물의 태그가 얼음일 경우
                {
                    //2. 물을 얼린다.
                }
                if(tag == fireTag)
                {
                    GameOver();
                }

                break;
        }
    }

    void GameOver()
    {
        Debug.Log("게임 오버!");
    }

}