using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHand : MonoBehaviour
{
    float angle;
    Vector3 target, mouse;

    private void Update()
    {
        target = GameManager.instance.PM.transform.position;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(Mathf.Abs(angle) > 90)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
