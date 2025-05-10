using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    //[SerializeField] private GameObject IceState; //자식 오브젝트 Ice

    //bool값을 이용해 얼음이 있는 지 없는 지 판단
    public bool isFrozen; //얼음이 붙어있는 지 확인
    private bool isState; //상호작용이 가능한 상태인지 확인
    private bool isCollision;

    private void Update()
    {
        Debug.Log("isState값 : " + isState);
    }
    private void OnCollisionStay2D(Collision2D collision) //얼음이 없으면 순차 실행
    {
        isCollision = true;
        SetState(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       isCollision= false;
        if (isFrozen) return;
        SetState(false);
    }

    public void SetFrozen(bool isFrozen)
    {
        bool originValue = this.isFrozen;
        if (!isCollision) return;

        this.isFrozen = isFrozen;
        Debug.Log(isFrozen == originValue ? "같은 타입" : this.isFrozen == true ? "얼림" : "녹임");
    }

    private void SetState(bool isState)
    {
        this.isState = isState;
        Debug.Log(this.isState == true ? "애니메이션 작동" : "애니메이션 작동XX");
    }
}

