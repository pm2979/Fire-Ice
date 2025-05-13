using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType { Normal, FireDoor, IceDoor }
public class ExitDoor : MonoBehaviour
{
    private Animator animator;
    public DoorType doorType;
    private bool firePlayerEntered = false;
    private bool icePlayerEntered = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (doorType)
        {
            case DoorType.Normal:
                if (col.CompareTag("PlayerIce")) icePlayerEntered=true;
                if (col.CompareTag("PlayerFire")) firePlayerEntered=true;
                if (firePlayerEntered && icePlayerEntered) animator.SetBool("IsOpen", true);
                //if(firePlayerEntered && icePlayerEntered) SoundManager.Instance.PlaySound(SoundType.SFX, "05_door_open_1");
                break;
            case DoorType.IceDoor:
                if (col.CompareTag("PlayerIce")) animator.SetBool("IsOpen", true);
                break;
            case DoorType.FireDoor:
                if (col.CompareTag("PlayerFire")) animator.SetBool("IsOpen", true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
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
