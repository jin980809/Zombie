using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ID;
    public int PrefabID;
    public float Damage;
    public int Count;
    public float Speed;



    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
   
    }

    //public void LevelUp(float Damage, int count)
    //{
    //    this.Damage += Damage;
    //    this.Count += count;
    //}


   public void Fire(Vector3 Dir)
    {
        Transform Bullet = GameManager.instance.PoolManager.Get(PrefabID).transform;
        Bullet.position = transform.position;
        Bullet.rotation = Quaternion.FromToRotation(Vector3.up, Dir);
        Bullet.GetComponent<Bullet>().Init(Damage, Count, Dir);
    }
}
