using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider HpBar;
    public Text KillCount;
    public GameObject GameOverUI;
    public GameObject GameClearUI;

    public static UIManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<UIManager>();
            }
            return m_Instance;
        }
    }

    private static UIManager m_Instance;

    private void Start()
    {
        GameOverUI.SetActive(false);
        GameClearUI.SetActive(false);
    }

    //private void Awake()
    //{
    //    if (m_Instance != null && m_Instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    m_Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    void Update()
    {
        HpBar.value = DataManager.Instance.Hp / DataManager.Instance.Max_Hp;
        KillCount.text = DataManager.Instance.KillCount.ToString();
    }
}
