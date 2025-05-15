using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitDoor : MonoBehaviour
{
    private Animator animator;
    public DOORTYPE doorType; // �� Ÿ�� ����

    private bool firePlayerEntered = false;
    private bool icePlayerEntered = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) // �� Ȱ��ȭ
    {
        switch (doorType)
        {
            case DOORTYPE.NORMAL: // �÷��̾� �� �� �־�� Ȱ��ȭ
                if (col.CompareTag("PlayerIce")) icePlayerEntered=true;
                if (col.CompareTag("PlayerFire")) firePlayerEntered=true;
                if (firePlayerEntered && icePlayerEntered)
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SOUNDTYPE.SFX, "05_door_open_1");
                }
                break;
            case DOORTYPE.ICEDOOR: // ���� �÷��̾� Ȱ��ȭ
                if (col.CompareTag("PlayerIce"))
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SOUNDTYPE.SFX, "05_door_open_1");
                }
                break;
            case DOORTYPE.FIREDOOR: // �� �÷��̾� Ȱ��ȭ
                if (col.CompareTag("PlayerFire"))
                {
                    animator.SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(SOUNDTYPE.SFX, "05_door_open_1");
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col) // �� ��Ȱ��ȭ
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
