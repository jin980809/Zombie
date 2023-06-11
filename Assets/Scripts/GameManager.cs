using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement PM;

    public float GameTime;
    public float MaxGameTime = 2 * 10.0f;

    public static GameManager instance;

    public PoolManager PoolManager;

    public Weapon WP;

    public Shooting ST;



    public enum WeaponState
    {
        Classic = 0,
        Shotgun = 1,
        Rifle = 2
    };

    public WeaponState _weaponState { get; set; }

    public WeaponState Curr_Weapon;

    void Start()
    {
    }

    void Awake()
    {
        instance = this;

    }

    void Update()
    {
        GameTime += Time.deltaTime;

        //if (GameTime > MaxGameTime)
        //{
        //    GameTime = MaxGameTime;
        //}

        if(PoolManager.EnemyCount == 0)
        {
            StageClear();
        }

        if(DataManager.Instance.Hp < 0)
        {
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        UIManager.Instance.GameOverUI.SetActive(true);
        PM.Speed = 0f;
        PM.GetComponent<Shooting>().enabled = false;
        PM.transform.GetChild(4).gameObject.SetActive(false);
    }

    void StageClear()
    {
        if (DataManager.Instance.curr_Stage == 3)
        {
            UIManager.Instance.GameClearUI.SetActive(true);
        }
        else
        {
            DataManager.Instance.curr_Stage++;
            string nextScene = "Stage" + (DataManager.Instance.curr_Stage).ToString();

            SceneManager.LoadScene(nextScene);
        }
    }
}
