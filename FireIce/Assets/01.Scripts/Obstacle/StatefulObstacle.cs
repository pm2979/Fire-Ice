using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulObstacle : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Melt()
    {
        Debug.Log("녹는 중");
        
    }

    public void Freeze()
    {
        Debug.Log("얼리는 중");
        //물 캐릭터와 충돌 시
        // 고정.
    }
}
