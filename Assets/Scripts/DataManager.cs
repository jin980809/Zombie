using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = FindObjectOfType<DataManager>();
            }
            return m_Instance;
        }
    }

    private static DataManager m_Instance;

    private void Awake()
    {
        if(m_Instance != null && m_Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public float Max_Hp = 100;
    public float Hp;
    public int KillCount = 0;

    public int curr_Stage;
    void Start()
    {
        Hp = Max_Hp;
        curr_Stage = 1;
    }
}
