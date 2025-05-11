using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false;

    [SerializeField] private float upPower = 10.5f; // ¶°¿À¸£´Â Èû



    private void OnTriggerStay2D(Collider2D col)
    {
        if (IsActive == true)
        {
            if(col.attachedRigidbody != null)
            {
                Rigidbody2D rb = col.attachedRigidbody;

                rb.gravityScale = 0;
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
