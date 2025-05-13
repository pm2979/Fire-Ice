using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour // 튜토리얼 설명 클래스
{
    public TextMeshProUGUI description; // 튜토리얼 설명
    int playerCount = 0; // 플레이어 확인

    private void OnTriggerEnter2D(Collider2D collision) // 충돌 물체가 플레이어면 튜토리얼 진행
    {
        if (collision.CompareTag("PlayerIce") || collision.CompareTag("PlayerFire"))
        {
            playerCount++; if (playerCount > 2) playerCount = 2;
            if(playerCount != 0)
            {
                description.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 플레이어 둘 다 나가면 튜토리얼 중단
    {
        if (collision.CompareTag("PlayerIce") || collision.CompareTag("PlayerFire"))
        {
            playerCount--;

            // 방어 코드: 음수로 내려가지 않게
            if (playerCount < 0) playerCount = 0;

            if (playerCount == 0 && description != null)
            {
                description.gameObject.SetActive(false);
            }
        }
    }
}
