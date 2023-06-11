using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;        // �߻��� ������
    public float launchSpeed = 10f;          // �߻� �ӵ�
    public float maxDistance = 10f;          // ������Ÿ���� ����� �ִ� �Ÿ�

    public Vector3 clickDirection;
    Vector3 characterPos;

    float timer;
    float waitingTime;

    void Start()
    {
        timer = 0;
        waitingTime = 0.1f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.Curr_Weapon == 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            characterPos = transform.position;
            characterPos.z = 0f;
            clickDirection = (mousePos - characterPos).normalized;
            GameManager.instance.WP.Fire(clickDirection);
            //Debug.Log(distance);
        }
        else if(Input.GetMouseButtonDown(0) && (int)GameManager.instance.Curr_Weapon == 1)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            characterPos = transform.position;
            characterPos.z = 0f;
            clickDirection = (mousePos - characterPos).normalized;

            GameManager.instance.WP.Fire(clickDirection);
            GameManager.instance.WP.Fire(CalculateC(10, characterPos, mousePos));
            GameManager.instance.WP.Fire(CalculateC(-10, characterPos, mousePos));
            GameManager.instance.WP.Fire(CalculateC(20, characterPos, mousePos));
            GameManager.instance.WP.Fire(CalculateC(-20, characterPos, mousePos));

        }
        else if (Input.GetMouseButton(0) && (int)GameManager.instance.Curr_Weapon == 2)
        {

            timer += Time.deltaTime;

            if (timer > waitingTime)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;

                characterPos = transform.position;
                characterPos.z = 0f;
                clickDirection = (mousePos - characterPos).normalized;
                GameManager.instance.WP.Fire(clickDirection);

                timer = 0;
            }

            
        }
    }

    private Vector3 CalculateC(int angle, Vector3 a, Vector3 b)
    {
        // a���� b������ ���� ���͸� ����մϴ�.
        Vector3 abDirection = (b - a).normalized;

        // a���� c������ ���� ���͸� ����մϴ�.
        Vector3 acDirection = Quaternion.Euler(0f, 0f, angle) * abDirection;

        // c�� ��ǥ�� ����մϴ�.
        Vector3 c = a + acDirection;

        Vector3 Result = (c - characterPos).normalized;

        return Result;
    }
}