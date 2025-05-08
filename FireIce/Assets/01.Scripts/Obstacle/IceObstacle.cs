using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceObstacle : MonoBehaviour
{
    public GameObject waterOb; //물 장애물
    public GameObject iceOb; //얼음 장애물

    public void Melt()
    {
        Debug.Log("불 캐릭터가 얼음을 녹입니다.");
        //불 캐릭터와 충돌 시
        //얼음 장애물 비전 끄기
        //물 장애물 비전 켜기
    }

    public void Freeze()
    {

    }
}
