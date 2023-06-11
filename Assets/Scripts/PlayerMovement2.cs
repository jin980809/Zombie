using UnityEngine;

public class PlayerMovement2: MonoBehaviour
{
    public float moveSpeed = 5f;     // �÷��̾� �̵� �ӵ�
    public float rotationSpeed = 200f;   // �÷��̾� ȸ�� �ӵ�

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // WASD Ű �Է� ó��
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �÷��̾� �̵�
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.velocity = movement * moveSpeed;

        // ���콺 ��ġ�� �÷��̾� ���� ���� ���� ���
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.Normalize();

        // �÷��̾� ȸ��
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}