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
            // �÷��̾�� �浿�ϸ� ����� ��ֹ� Ȱ��ȭ
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj[i].GetComponent<IObstacleActive>().IsActive == false)
            {
                var obstacle = obstacleObj[i].GetComponent<IObstacleActive>();
                obstacle.IsActiveTrue();
                animator.SetBool("IsOn", true);
            }
            // �÷��̾�� �浿�ϸ� ����� ��ֹ� ��Ȱ��ȭ
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj[i].GetComponent<IObstacleActive>().IsActive == true)
            {
                var obstacle = obstacleObj[i].GetComponent<IObstacleActive>();
                obstacle.IsActiveFalse();
                animator.SetBool("IsOn", false);
            }
        }
    }
}
