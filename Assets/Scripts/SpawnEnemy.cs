using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] Spawn_Point;
    public SpawnData[] SpawnData;
    float Timer;

    public int Level;
    void Awake()
    {
        Spawn_Point = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        Level = Mathf.FloorToInt(GameManager.instance.GameTime / 10.0f);

        if (Level < SpawnData.Length)
        {
            if (Timer > SpawnData[Level].spawnTime)
            {
                Spawn();
                Timer = 0f;
            }
        }

    }

    void Spawn()
    {
        GameObject Enemy = GameManager.instance.PoolManager.Get(0);
        Enemy.transform.position = Spawn_Point[Random.Range(1, Spawn_Point.Length)].position;
        Enemy.GetComponent<Enemy>().Init(SpawnData[Level]);
        GameManager.instance.PoolManager.EnemyCount++;
    }
}

[System.Serializable] 
public class SpawnData
{
    public float spawnTime;

    public int spriteType;
    public int health;
    public float speed;
}
