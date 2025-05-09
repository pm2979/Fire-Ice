using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObstacleObj.GetComponent<IObstacleActive>().IsActive = true;
        animator.SetBool("IsOn", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ObstacleObj.GetComponent<IObstacleActive>().IsActive = false;
        animator.SetBool("IsOn", false);
    }
}
