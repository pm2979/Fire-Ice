using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public float groundCheckDistance = 0.75f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float currentZRotation = 0f;
    private float moveInput = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Input();
        Rotation();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Input() // 입력 메서드
    {
        // 좌/우 입력
        if (UnityEngine.Input.GetKey(leftKey))
            moveInput = -1f;
        else if (UnityEngine.Input.GetKey(rightKey))
            moveInput = 1f;
        else
            moveInput = 0f;

        // 점프 입력
        if (UnityEngine.Input.GetKeyDown(jumpKey) && IsGrounded())
            Jump();
    }

    private void Movement() // 플레이어 움직임
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump() // 플레이어 점프
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Rotation() // 플레이어 회전
    {
        // 좌우 이동 중일 때만 회전
        if (moveInput == 0f) return;

        float rotationSpeed = 200f;
        currentZRotation += -rotationSpeed * moveInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }

    bool IsGrounded() // 땅인지 확인
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    
}
