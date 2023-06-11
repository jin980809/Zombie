using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    Collider2D Col;
    void Awake()
    {
        Col = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("Area"))
        {
            return;
        }

        Vector3 Player_Pos = GameManager.instance.PM.transform.position;
        Vector3 My_Pos = transform.position;

        float Distance_X = Mathf.Abs(Player_Pos.x - My_Pos.x);
        float Distance_Y = Mathf.Abs(Player_Pos.y - My_Pos.y);

        Vector3 Player_Dir = GameManager.instance.PM.Input_Vector;

        float Dir_X = Player_Dir.x < 0 ? -1 : 1;
        float Dir_Y = Player_Dir.y < 0 ? -1 : 1;

        switch(transform.tag)
        {
            case "Ground":
                if(Distance_X > Distance_Y)
                {
                    transform.Translate(Vector3.right * Dir_X * 40);
                }
                else if(Distance_X < Distance_Y)
                {
                    transform.Translate(Vector3.up * Dir_Y * 40);
                }
                break;

            case "Enemy":
                if(Col.enabled)
                {
                    transform.Translate(Player_Dir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;

        }
    }

}
