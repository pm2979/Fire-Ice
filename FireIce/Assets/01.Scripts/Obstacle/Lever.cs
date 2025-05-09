using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject obstacleObj;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj.GetComponent<ISwitchActive>().IsActive == false)
        {
            obstacleObj.GetComponent<ISwitchActive>().IsActive = true;
            animator.SetBool("IsOn", true);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && obstacleObj.GetComponent<ISwitchActive>().IsActive == true)
        {
            obstacleObj.GetComponent<ISwitchActive>().IsActive = false;
            animator.SetBool("IsOn", false);
        }
    }
}
