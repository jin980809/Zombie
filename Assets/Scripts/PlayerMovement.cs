using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 Input_Vector;
    public float Speed = 5f;

    Rigidbody2D RB;
    SpriteRenderer SP;

    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SP = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Input_Vector.x = Input.GetAxis("Horizontal");
        Input_Vector.y = Input.GetAxis("Vertical");

        Vector2 Move = Input_Vector.normalized * Speed * Time.fixedDeltaTime;
        //RB.velocity = Input_Vector;
        RB.MovePosition(RB.position + Move);
    }

    void LateUpdate()
    {
        Anim.SetFloat("Speed", Input_Vector.magnitude);

        if(Input_Vector.x != 0)
        {
            SP.flipX = Input_Vector.x < 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DataManager.Instance.Hp -= Time.deltaTime * 10f;

        if(DataManager.Instance.Hp < 0)
        {
            Anim.SetTrigger("Dead");
            Speed = 0f;
        }
    }

}
