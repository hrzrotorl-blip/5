using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;     // 걷기 속도
    public float jumpForce = 7f;     // 점프 높이
    public float airControl = 0.5f;  // 공중 이동 조정(0~1)

    private Rigidbody rb;
    private bool isGrounded = false;
    private Vector3 inputDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 회전 방지 (넘어지지 않게)
    }

    void Update()
    {
        // --- 이동 입력 ---
        float h = Input.GetAxisRaw("Horizontal"); // A,D or ←, →
        float v = Input.GetAxisRaw("Vertical");   // W,S or ↑, ↓
        inputDir = new Vector3(h, 0f, v).normalized;

        // --- 점프 입력 ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // 이동 방향 계산 (카메라 기준이 아니라 월드 기준)
        Vector3 move = transform.TransformDirection(inputDir) * moveSpeed;

        // 공중 제어 (isGrounded 아닐 때는 제어력 줄이기)
        if (!isGrounded)
            move *= airControl;

        Vector3 velocity = rb.velocity;
        velocity.x = move.x;
        velocity.z = move.z;
        rb.velocity = velocity;
    }

    void Jump()
    {
        // 위쪽으로 점프 힘 추가
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // 기존 y속도 초기화
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // --- 바닥 접촉 감지 ---
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
