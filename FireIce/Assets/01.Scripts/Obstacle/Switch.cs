using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //자식 오브젝트 Ice

    //bool값을 이용해 얼음이 있는 지 없는 지 판단
    public bool isFrozen { get; set; } //얼음이 붙어있는 지 확인
    private bool isState; //상호작용이 가능한 상태인지 확인
   
    private void OnCollisionStay2D(Collision2D collision) //얼음이 없으면 순차 실행
    {
        //if (collision.gameObject.GetComponent<Ability>().abilityType == ABILITYTYPE.FIRE)
        
        if (isFrozen) return; //얼음이 있으면 실행 x

        isState = true;

        HandleSwitchInput();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isFrozen) return;

        isState = false;

        HandleSwitchInput();
    }

    private void HandleSwitchInput()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool isActive = isState;

            //ObstacleObj.GetComponent<IObstacleActive>().IsActive = isActive;
            animator.SetBool("IsOn", isActive);
            Debug.Log("반응 중");
        }
    }
}

