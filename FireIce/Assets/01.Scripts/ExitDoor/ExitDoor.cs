using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType { Normal, FireDoor, IceDoor }
public class ExitDoor : MonoBehaviour
{
    private Animator animator;
    public DoorType doorType; // 문 타입 결정

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
            case DoorType.Normal: // 플레이어 둘 다 있어야 활성화
                if (col.CompareTag("PlayerIce")) icePlayerEntered=true;
                if (col.CompareTag("PlayerFire")) firePlayerEntered=true;
                if (firePlayerEntered && icePlayerEntered)
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SoundType.SFX, "05_door_open_1");
                }
                break;
            case DoorType.IceDoor: // 얼음 플레이어 활성화
                if (col.CompareTag("PlayerIce"))
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SoundType.SFX, "05_door_open_1");
                }
                break;
            case DoorType.FireDoor: // 불 플레이어 활성화
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
            case DoorType.Normal:
                if (col.CompareTag("PlayerIce")) icePlayerEntered = false;
                if (col.CompareTag("PlayerFire")) firePlayerEntered = false;
                if (!firePlayerEntered || !icePlayerEntered) animator.SetBool("IsOpen", false);
                break;
            case DoorType.IceDoor:
                if (col.CompareTag("PlayerIce")) animator.SetBool("IsOpen", false);
                break;
            case DoorType.FireDoor:
                if (col.CompareTag("PlayerFire")) animator.SetBool("IsOpen", false);
                break;
        }
    }

}
