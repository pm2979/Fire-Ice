using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitDoor : MonoBehaviour
{
    private Animator animator;
    public DOORTYPE doorType; // 문 타입 결정

    private bool firePlayerEntered = false;
    private bool icePlayerEntered = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) // 문 활성화
    {
        switch (doorType)
        {
            case DOORTYPE.NORMAL: // 플레이어 둘 다 있어야 활성화
                if (col.CompareTag("PlayerIce")) icePlayerEntered=true;
                if (col.CompareTag("PlayerFire")) firePlayerEntered=true;
                if (firePlayerEntered && icePlayerEntered)
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SoundType.SFX, "05_door_open_1");
                }
                break;
            case DOORTYPE.ICEDOOR: // 얼음 플레이어 활성화
                if (col.CompareTag("PlayerIce"))
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SoundType.SFX, "05_door_open_1");
                }
                break;
            case DOORTYPE.FIREDOOR: // 불 플레이어 활성화
                if (col.CompareTag("PlayerFire"))
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SoundType.SFX, "05_door_open_1");
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col) // 문 비활성화
    {
        switch (doorType)
        {
            case DOORTYPE.NORMAL:
                if (col.CompareTag("PlayerIce")) icePlayerEntered = false;
                if (col.CompareTag("PlayerFire")) firePlayerEntered = false;
                if (!firePlayerEntered || !icePlayerEntered) animator.SetBool("IsOpen", false);
                break;
            case DOORTYPE.ICEDOOR:
                if (col.CompareTag("PlayerIce")) animator.SetBool("IsOpen", false);
                break;
            case DOORTYPE.FIREDOOR:
                if (col.CompareTag("PlayerFire")) animator.SetBool("IsOpen", false);
                break;
        }
    }

}
