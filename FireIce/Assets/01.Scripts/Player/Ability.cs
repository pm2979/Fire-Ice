using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public const string fireTag = "Fire Obstacle"; //�� Tag (���Ǯ)
    public const string iceTag = "Ice Obstacle"; //���� Tag (����Ǯ)
    public const string poisonTag = "Poison Obstacle"; //�� Tag

    protected IFrozen frozenTarget = null; //�÷��̾�� �浹�� ������Ʈ�� IFrozen�� ������ ���� �� �浹�� ������Ʈ�� ������ ����

    private void Update()
    {
        if (InputKeyAbility() && frozenTarget != null) //�Ʒ� Ű�� �Է¹ް� frozenTarget�� �ִٸ�,
        {
            HandleIFrozen(frozenTarget);
        }
    }

    protected abstract bool InputKeyAbility(); //�Ʒ� Ű �Է¹޴� �޼���

    public virtual void Interact(GameObject target) //��ȣ�ۿ�(�÷��̾�-������Ʈ)
    {
        string targetTag = target.tag; //�±׸� �����ͼ�,

        if(targetTag == poisonTag) //���� ������ ���ӿ���
        {
            GameOver();
        }
        else if(targetTag == iceTag) //������ �ε�����,
        {
            InIcePool();
        }
        else if(targetTag == fireTag) //�Ұ� �ε�����,
        {
            InFirePool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�浹�� ���۵� �� ����
    {
        Interact(collision.gameObject); //Interact�� ó��
    }

    private void OnCollisionStay2D(Collision2D collision) //�浹�� ���۵� �� ����
    {
        if (collision.gameObject.GetComponent<IFrozen>() != null) //�浹�� ������Ʈ���� frozen�� ã��
        {
            frozenTarget = collision.gameObject.GetComponent<IFrozen>(); //frozenTarget�� ����
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //�浹�� ���� �� ����
    {
        if(frozenTarget != null)
            frozenTarget = null;
    }

    public void GameOver()
    {
        SoundManager.Instance.PlaySound(SOUNDTYPE.SFX, "13_human_jump_land_1");
        GameManager.Instance.GameOverUI();
        //AchievementConditions.deathCount++;
        Debug.Log("���� ����!");

    }
    protected virtual void HandleIFrozen(IFrozen frozen)
    {
        //����ġ ��/���� ó�� | �ڽ� Ŭ�������� ����
    }
    protected virtual void InFirePool()
    {
        // �÷��̾ ���� ���� ���� or Debug.Log | �ڽ� Ŭ�������� ����
    }
    protected virtual void InIcePool()
    {
        // �÷��̾ ���� ���� ���� or Debug.Log | �ڽ� Ŭ�������� ����
    }
}