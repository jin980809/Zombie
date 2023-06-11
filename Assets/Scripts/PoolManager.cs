using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Enemys;

    List<GameObject>[] Pools;

    public int EnemyCount;
    void Awake()
    {
        Pools = new List<GameObject>[Enemys.Length];

        for(int i = 0; i < Pools.Length; i++)
        {
            Pools[i] = new List<GameObject>();
        }
    }

    void Start()
    {
        EnemyCount = 1;
        StartCoroutine(DelayTime());

    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in Pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(select == null)
        {
            select = Instantiate(Enemys[index], transform);
            Pools[index].Add(select);
        }

        return select;
    }

    IEnumerator DelayTime()
    {

        yield return new WaitForSeconds(1f);
        EnemyCount--;
    }
}
