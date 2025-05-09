using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //자식 오브젝트 Ice

    //bool값을 이용해 얼음이 있는 지 없는 지 판단
    public bool isFrozen { get; set; } //얼음이 붙어있는 지 확인


    private void OnCollisionEnter2D(Collision2D collision) //얼음이 밟았을 때
    {
        if (isFrozen == true)
        {
            ObstacleObj.GetComponent<ISwitchActive>().IsActive = true;
            animator.SetBool("IsOn", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //불이 밟았을 때
    {
        if (isFrozen == false)
        {
            ObstacleObj.GetComponent<ISwitchActive>().IsActive = false;
            animator.SetBool("IsOn", false);
        }
    }
}

