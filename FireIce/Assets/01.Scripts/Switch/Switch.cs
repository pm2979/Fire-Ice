using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour ,IFrozen
{
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private Animator animator;
    [field: SerializeField] public bool IsFrozen { get; set; } = false;
    [field: SerializeField] public GameObject IceObj { get; set; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsFrozen) return;
        ObstacleObj.gameObject.GetComponent<IObstacleActive>().IsActive = true;
        animator.SetBool("IsOn", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsFrozen) return;
        ObstacleObj.gameObject.GetComponent<IObstacleActive>().IsActive = false;
        animator.SetBool("IsOn", false);
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

