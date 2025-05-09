using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject obstacleObj;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 충동하면 연결된 장애물 활성화
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj.GetComponent<IObstacleActive>().IsActive == false)
        {
            obstacleObj.GetComponent<IObstacleActive>().IsActive = true;
            animator.SetBool("IsOn", true);
        }
        // 플레이어와 충동하면 연결된 장애물 비활성화
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj.GetComponent<IObstacleActive>().IsActive == true)
        {
            obstacleObj.GetComponent<IObstacleActive>().IsActive = false;
            animator.SetBool("IsOn", false);
        }
    }
}
