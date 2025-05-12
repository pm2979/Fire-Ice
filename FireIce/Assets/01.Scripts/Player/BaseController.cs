using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public float groundCheckDistance = 0.75f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float currentZRotation = 0f;
    private float moveInput = 0f;
    private bool isJump; // 점프 가능 여부
    private RaycastHit2D hit;

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
        Slide();
    }

    private void Input() // 입력 메서드
    {
        IsGrounded(); // 플레이어가 땅 위인지 확인

        // 좌/우 입력
        if (UnityEngine.Input.GetKey(leftKey))
        {
            if(isJump == true) moveInput = -1f;
            if(isJump == false) moveInput = -0.5f;

        }
        else if (UnityEngine.Input.GetKey(rightKey))
        {
            if (isJump == true) moveInput = 1f;
            if (isJump == false) moveInput = 0.5f;
        }
        else moveInput = 0f;

        // 점프 입력
        if (UnityEngine.Input.GetKeyDown(jumpKey) && isJump == true)
            Jump();
    }

    private void Movement() // 플레이어 움직임
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump() // 플레이어 점프
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJump = true;
    }

    private void Slide()
    {
        if (hit.collider == null) return; // 공중에 떠 있는 상태 > 슬라이드 멈춤

        // 경사각 계산 (법선 벡터와 Up 벡터의 각도)
        float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

        if (slopeAngle > 20f) // 각도가 20도 이상이면
        {
            // 경사면을 따라 내려가는 방향 구하기
            Vector2 slideDirection = new Vector2(hit.normal.y, -hit.normal.x);

            // 위쪽 방향으로 향해 있으면 반전
            if (slideDirection.y > 0) slideDirection = -slideDirection;
            slideDirection.Normalize();

            // 속도 강제 설정 (중력 방향이 아닌 경사면 방향)
            rb.velocity = slideDirection;
        }
    }

    private void Rotation() // 플레이어 회전
    {
        // 좌우 이동 중일 때만 회전
        if (moveInput == 0f) return;

        float rotationSpeed = 200f;
        currentZRotation += -rotationSpeed * moveInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }
    

    private void IsGrounded() // 땅인지 확인
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isJump = hit.collider != null ? true : false;
    }
}
