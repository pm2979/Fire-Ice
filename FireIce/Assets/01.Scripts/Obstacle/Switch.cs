using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //자식 오브젝트 Ice

    //bool값을 이용해 얼음이 있는 지 없는 지 판단
    private bool isFrozen; //얼음 유무 판단
    private bool isState; //상호작용이 가능한 상태인지 확인
    private bool isCollision; //충돌 여부 판단

    private void Update()
    {
        Debug.Log("isState : " + isState); //왜 충돌 시에도 false가 같이 올라가는지=============================
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isCollision = true;
        Debug.Log("isCollision : " + isCollision);
        SetState(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       isCollision= false;
        if (isFrozen)
        {
            return;
        }
        SetState(false);
    }

    public void SetFrozen(bool isFrozen)
    {
        bool originValue = this.isFrozen;
        if (!isCollision) return;

        Debug.Log("SetFrozen - originValue : " + originValue);
        this.isFrozen = isFrozen;
        Debug.Log("SetFrozen - isFrozen : " + isFrozen);
        Debug.Log(isFrozen == originValue ? "같은 타입" : this.isFrozen == true ? "얼림" : "녹임");
    }

    private void SetState(bool isState)
    {
        //if (isState == this.isState) return;
        this.isState = isState;
        Debug.Log(this.isState == true ? "애니메이션 작동" : "애니메이션 미작동");
    }
}

