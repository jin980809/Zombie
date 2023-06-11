using UnityEngine;

public class PlayerMovement2: MonoBehaviour
{
    public float moveSpeed = 5f;     // 플레이어 이동 속도
    public float rotationSpeed = 200f;   // 플레이어 회전 속도

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // WASD 키 입력 처리
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 플레이어 이동
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.velocity = movement * moveSpeed;

        // 마우스 위치와 플레이어 간의 방향 벡터 계산
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.Normalize();

        // 플레이어 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}