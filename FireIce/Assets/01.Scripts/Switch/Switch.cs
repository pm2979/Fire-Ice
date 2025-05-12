using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour ,IFrozen
{
    [SerializeField] private GameObject[] ObstacleObj;
    [SerializeField] private Animator animator;
    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }


    private void Start()
    {
        IsIceActive(IsFrozen);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsFrozen) return;
        
        for (int i = 0; i < ObstacleObj.Length; i++)
        {
            var obstacle = ObstacleObj[i].GetComponent<IObstacleActive>();
            obstacle.IsActiveTrue();
            animator.SetBool("IsOn", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsFrozen) return;
        
        for (int i = 0; i < ObstacleObj.Length; i++)
        {
            var obstacle = ObstacleObj[i].GetComponent<IObstacleActive>();
            obstacle.IsActiveFalse();
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

