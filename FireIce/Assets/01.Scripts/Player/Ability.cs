using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public const string fireTag = "Fire Obstacle"; //불 Tag (용암풀)
    public const string iceTag = "Ice Obstacle"; //얼음 Tag (얼음풀)
    public const string poisonTag = "Poison Obstacle"; //독 Tag

    protected IFrozen frozenTarget = null; //플레이어와 충돌한 오브젝트가 IFrozen을 가지고 있을 때 충돌한 오브젝트를 저장할 변수

    private void Update()
    {
        if (InputKeyAbility() && frozenTarget != null) //아래 키를 입력받고 frozenTarget이 있다면,
        {
            HandleIFrozen(frozenTarget);
        }
    }

    protected abstract bool InputKeyAbility(); //아래 키 입력받는 메서드

    public virtual void Interact(GameObject target) //상호작용(플레이어-오브젝트)
    {
        string targetTag = target.tag; //태그를 가져와서,

        if(targetTag == poisonTag) //독에 빠지면 게임오버
        {
            GameOver();
        }
        else if(targetTag == iceTag) //얼음과 부딪히면,
        {
            InIcePool();
        }
        else if(targetTag == fireTag) //불과 부딪히면,
        {
            InFirePool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //충돌이 시작될 때 실행
    {
        Interact(collision.gameObject); //Interact로 처리
    }

    private void OnCollisionStay2D(Collision2D collision) //충돌이 시작될 때 실행
    {
        if (collision.gameObject.GetComponent<IFrozen>() != null) //충돌한 오브젝트에서 frozen을 찾음
        {
            frozenTarget = collision.gameObject.GetComponent<IFrozen>(); //frozenTarget에 저장
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //충돌이 끝날 때 실행
    {
        if(frozenTarget != null)
            frozenTarget = null;
    }

    public void GameOver()
    {
        SoundManager.Instance.PlaySound(SoundType.SFX, "21_orc_damage_3");
        GameManager.Instance.GameOverUI();
        Debug.Log("게임 오버!");
    }
    protected virtual void HandleIFrozen(IFrozen frozen)
    {
        //스위치 얼림/녹임 처리 | 자식 클래스에서 정의
    }
    protected virtual void InFirePool()
    {
        // 플레이어에 따라 게임 오버 or Debug.Log | 자식 클래스에서 정의
    }
    protected virtual void InIcePool()
    {
        // 플레이어에 따라 게임 오버 or Debug.Log | 자식 클래스에서 정의
    }
}