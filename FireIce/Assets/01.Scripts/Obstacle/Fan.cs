using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false;

    [SerializeField] private float upPower = 10.5f; // ¶°¿À¸£´Â Èû
    [SerializeField] private ParticleSystem windParticle;

    private void Start()
    {
        if (IsActive == true) windParticle.Play();
        else windParticle.Stop();
    }

    public void IsActiveTrue()
    {
        IsActive = true;
        windParticle.Play();
    }

    public void IsActiveFalse()
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

                rb.gravityScale = 0f;
                rb.AddForce(Vector2.up * upPower, ForceMode2D.Force);
            }
        }
        else
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
