using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacleObj;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < obstacleObj.Length; i++)
        {
            // 플레이어와 충동하면 연결된 장애물 활성화
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj[i].GetComponent<IObstacleActive>().IsActive == false)
            {
                var obstacle = obstacleObj[i].GetComponent<IObstacleActive>();
                obstacle.IsActive = !obstacle.IsActive;
                animator.SetBool("IsOn", true);
            }
            // 플레이어와 충동하면 연결된 장애물 비활성화
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj[i].GetComponent<IObstacleActive>().IsActive == true)
            {
                var obstacle = obstacleObj[i].GetComponent<IObstacleActive>();
                obstacle.IsActive = !obstacle.IsActive;
                animator.SetBool("IsOn", false);
            }
        }




    }
}
