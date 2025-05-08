using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(leftKey)) moveX = -1f;
        if (Input.GetKey(rightKey)) moveX = 1f;

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (moveX < 0) spriteRenderer.flipX = true;
        else if (moveX > 0) spriteRenderer.flipX = false;

        if (Input.GetKeyDown(jumpKey) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
