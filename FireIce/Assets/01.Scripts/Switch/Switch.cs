using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour ,IFrozen
{
    [SerializeField] private GameObject[] ObstacleObj;
    [SerializeField] private Animator animator;
    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < ObstacleObj.Length; i++)
        {
            if (IsFrozen) return;
            var obstacle = ObstacleObj[i].GetComponent<IObstacleActive>();
            obstacle.IsActive = !obstacle.IsActive;
            animator.SetBool("IsOn", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < ObstacleObj.Length; i++)
        {
            if (IsFrozen) return;
            var obstacle = ObstacleObj[i].GetComponent<IObstacleActive>();
            obstacle.IsActive = !obstacle.IsActive;
            animator.SetBool("IsOn", false);
        }
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

