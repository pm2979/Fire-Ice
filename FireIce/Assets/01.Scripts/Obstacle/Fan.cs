using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false;

    [SerializeField] private float upPower = 10.5f; // 떠오르는 힘
    [SerializeField] private ParticleSystem windParticle;

    private void Start()
    {
        // 시작 파티클
        if (IsActive == true) windParticle.Play();
        else windParticle.Stop();
    }

    public void IsActiveTrue() // Fan 활성화
    {
        IsActive = true;
        windParticle.Play();
    }

    public void IsActiveFalse() // Fan 비활성화
    {
        IsActive = false;
        windParticle.Stop();
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (IsActive == true)
        {
            if(col.attachedRigidbody != null)
            {
                Rigidbody2D rb = col.attachedRigidbody;

                // 플레이어 상승
                rb.gravityScale = 0f;
                rb.AddForce(Vector2.up * upPower, ForceMode2D.Force);
            }
        }
        else // 상승 중 비활성화
        {
            Rigidbody2D rb = col.attachedRigidbody;

            rb.gravityScale = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Rigidbody2D rb = col.attachedRigidbody;

        rb.gravityScale = 1;
    }
}
