using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{
    public TextMeshProUGUI description;
    int playerCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
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

    private void OnTriggerExit2D(Collider2D collision)
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
