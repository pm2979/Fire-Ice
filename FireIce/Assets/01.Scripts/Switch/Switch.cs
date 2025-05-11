using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour ,IFrozen
{
    [SerializeField] private GameObject[] ObstacleObj;
    [SerializeField] private Animator animator;
    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }

    private void ObstacleActive(bool isActive) // 장애물 활성화 비활성화
    {
        for (int i = 0; i < ObstacleObj.Length; i++)
        {
            var obstacle = ObstacleObj[i].GetComponent<IObstacleActive>();
            obstacle.IsActive = isActive;
            animator.SetBool("IsOn", isActive);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsFrozen) return;

        ObstacleActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsFrozen) return;

        ObstacleActive(false);
    }

    public void IsFrozenTrue()
    {
        IsFrozen = true;
        IsIceActive(IsFrozen);
    }

    public void IsFrozenFalse()
    {
        IsFrozen = false;
        IsIceActive(IsFrozen);
    }

    public void IsIceActive(bool isIce)
    {
        IceObj.SetActive(isIce);
    }
}

