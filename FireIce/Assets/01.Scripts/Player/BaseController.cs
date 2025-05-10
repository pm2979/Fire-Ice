using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    public KeyCode downKey = KeyCode.S;
    [SerializeField] private LayerMask layer;

    public float groundCheckDistance = 0.75f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float currentZRotation = 0f;
    private float moveInput = 0f;
    private bool isJump; // 점프 가능 여부

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

        // 아래 키
        if (UnityEngine.Input.GetKeyDown(downKey))
        {
            Debug.DrawRay(transform.position, Vector2.down * 2f, Color.green, 0.5f); //체크
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Interaction"));
            //Debug.Log("Trigger 감지 설정: " + Physics2D.queriesHitTriggers);

            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                Debug.Log("충돌체 : " + hit.collider.name);

                Ability ability = GetComponent<Ability>();
                if(ability != null)
                {
                    gameObject.GetComponent<Ability>().Interact(hit.collider.gameObject);
                    //ability.Interact(hit.collider.gameObject);
                }
                else
                {
                    Debug.LogWarning("Ability NU11");
                }
            }
            else { Debug.LogWarning("Raycast NU11"); }
        }
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isJump = hit.collider != null ? true : false;
    }

    
}
