using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public RuntimeAnimatorController[] Anim_Controller;

    public float Hp;
    public float Max_Hp;

    public Rigidbody2D Target;

    public bool is_Live;

    Rigidbody2D RB;
    SpriteRenderer SR;
    Collider2D Col;
    Animator Anim;
    WaitForFixedUpdate Wait;

    void Awake()
    {
        Wait = new WaitForFixedUpdate();
        RB = GetComponent<Rigidbody2D>();
        Col = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!is_Live || Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit") )
        {
            return;
        }

        Vector2 Dir_Vec = Target.position - RB.position;
        Vector2 Next_Vec = Dir_Vec.normalized * Speed * Time.fixedDeltaTime;

        RB.MovePosition(RB.position + Next_Vec);

        RB.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!is_Live)
        {
            return;
        }

        SR.flipX = Target.position.x < RB.position.x;
    }
    void OnEnable()
    {
        Target = GameManager.instance.PM.GetComponent<Rigidbody2D>();
        is_Live = true;
        Col.enabled = true;
        RB.simulated = true;
        SR.sortingOrder = 2;
        Anim.SetBool("Dead", false);
        Hp = Max_Hp;
    }
    public void Init(SpawnData data)
    {
        Anim.runtimeAnimatorController = Anim_Controller[data.spriteType];
        Speed = data.speed;
        Max_Hp = data.health;
        Hp = data.health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Bullet"))
        {
            return;
        }

        Hp -= other.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if(Hp > 0)
        {
            Anim.SetTrigger("Hit");
        }
        else
        {
            is_Live = false;
            Col.enabled = false;
            RB.simulated = false;
            SR.sortingOrder = 1;
            Anim.SetBool("Dead", true);
            DataManager.Instance.KillCount++;
        }
    }

    IEnumerator KnockBack()
    {
        yield return Wait;
        Vector3 player_Pos = GameManager.instance.PM.transform.position;
        Vector3 dirVec = transform.position - player_Pos;
        RB.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }

    void Dead()
    {
        gameObject.SetActive(false);
        GameManager.instance.PoolManager.EnemyCount--;
    }
}
