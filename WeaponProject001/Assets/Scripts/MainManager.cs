using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public BoxCollider2D boxclollider;//클릭영역부분
    public GameObject Enemy;
    public GameObject bullet;
    static GameObject shootBull;

    struct Weapons
    {
        static bool ex;
        static int atk;
        static int level;
        static int Wclass;
    }
    //기본재화
    static int gold;
    //무기 슬롯 활성 유무
    static int W1e=0;
    static int W2e=0;
    static int W3e=0;
    static int W4e=0;
    //무기 공격력
    static int W1atk;
    static int W2atk;
    static int W3atk;
    static int W4atk;
    //무기 레벨
    static int W1level;
    static int W2level;
    static int W3level;
    static int W4level;
    //무기 클래스
    static int W1class;
    static int W2class;
    static int W3class;
    static int W4class;
    //무기 강화비용
    static int W1upgradeGold;
    static int W2upgradeGold;
    static int W3upgradeGold;
    static int W4upgradeGold;
    //무기 강화공격력증가수치
    static int W1upgradeAtk;
    static int W2upgradeAtk;
    static int W3upgradeAtk;
    static int W4upgradeAtk;

    //무기슬롯 버튼
    public GameObject W1BTN;
    public GameObject W2BTN;
    public GameObject W3BTN;
    public GameObject W4BTN;

    //무기 이미지
    public RuntimeAnimatorController[] weaponClass;
    //public RuntimeAnimatorController weaponClass002;
    //public RuntimeAnimatorController weaponClass003;
    //public RuntimeAnimatorController weaponClass004;

    //무기슬롯
    public GameObject weapon001;
    public GameObject weapon002;
    public GameObject weapon003;
    public GameObject weapon004;

    public static int EnemyHP;




    // Use this for initialization
    void Start () {
        // PlayerPrefs.SetInt("ENEMYHP", 100);
        //PlayerPrefs.SetInt("W1ATK", 5);
        /*
        PlayerPrefs.SetInt("W1E",0);
        PlayerPrefs.SetInt("W2E", 0);
        PlayerPrefs.SetInt("W3E", 0);
        PlayerPrefs.SetInt("W4E", 0);

        PlayerPrefs.SetInt("W1CLASS", 0);
        PlayerPrefs.SetInt("W2CLASS", 0);
        PlayerPrefs.SetInt("W3CLASS", 0);
        PlayerPrefs.SetInt("W4CLASS", 0);
        */

        //Debug.Log(W1e);
        //Debug.Log(PlayerPrefs.GetInt("W!E"));
        W1e = PlayerPrefs.GetInt("W1E");
       // Debug.Log(W1e);
       //Debug.Log(PlayerPrefs.GetInt("W!E"));

        W2e = PlayerPrefs.GetInt("W2E");
        W3e = PlayerPrefs.GetInt("W3E");
        W4e = PlayerPrefs.GetInt("W4E");
        W1class = PlayerPrefs.GetInt("W1CLASS");
        W2class = PlayerPrefs.GetInt("W2CLASS");
        W3class = PlayerPrefs.GetInt("W3CLASS");
        W4class = PlayerPrefs.GetInt("W4CLASS");
        W1atk = PlayerPrefs.GetInt("W1ATK");
        W2atk = PlayerPrefs.GetInt("W2ATK");
        W3atk = PlayerPrefs.GetInt("W3ATK");
        W4atk = PlayerPrefs.GetInt("W4ATK");
        EnemyHP = PlayerPrefs.GetInt("ENEMYHP");
        
        checkWeapon();

    }
	
	// Update is called once per frame
	void Update () {
        int state=1;
        /*
        PlayerPrefs.SetInt("W1E", 0);
        PlayerPrefs.SetInt("W2E", 0);
        PlayerPrefs.SetInt("W3E", 0);
        PlayerPrefs.SetInt("W4E", 0);

        PlayerPrefs.SetInt("W1CLASS", 0);
        PlayerPrefs.SetInt("W2CLASS", 0);
        PlayerPrefs.SetInt("W3CLASS", 0);
        PlayerPrefs.SetInt("W4CLASS", 0);
        */
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (state==0)
        {
            weapon001.GetComponent<Animator>().Play("Base Layer.state_idle",1);
        }
        else
        {
            state = 0;
        }

        if (rayhit.collider != null)
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0))
            {
                weapon001.GetComponent<Animator>().Play("Base Layer.state_shoot");
                state = 1;
                shootBull = Instantiate(bullet,weapon001.transform.position+new Vector3(0.8f,0.3f,0),bullet.transform.rotation) as GameObject;
                shootBull.name = bullet.name + "_" + Time.time;
                Debug.Log("HP"+EnemyHP);
            }
        }

        EnemyHP = PlayerPrefs.GetInt("ENEMYHP");

    }

    void checkWeapon()
    {

        if (W1e == 1)
        {
            W1BTN.SetActive(false);
            weapon001.SetActive(true);
            weapon001.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W1class-1];

        }
        if (W2e == 1)
        {
            W2BTN.SetActive(false);
            weapon002.SetActive(true);
            weapon002.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W2class - 1];

        }
        if (W3e == 1)
        {
            W3BTN.SetActive(false);
            weapon003.SetActive(true);
            weapon003.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W3class - 1];

        }
        if (W4e == 1)
        {
            W4BTN.SetActive(false);
            weapon004.SetActive(true);
            weapon004.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W4class - 1];

        }
        
    }

    public void BuyWeapon(int WNUM)
    {
        if (WNUM == 1)
        {
            
            W1e = 1;
            W1class = 1;
            PlayerPrefs.SetInt("W1E", W1e);
            PlayerPrefs.SetInt("W1CLASS", W1class);
            Debug.Log(W1e);
            Debug.Log(PlayerPrefs.GetInt("W1E"));
            W1BTN.SetActive(false);
            weapon001.SetActive(true);
            weapon001.GetComponent<Animator>().runtimeAnimatorController = weaponClass[0];


        }
        else if (WNUM == 2)
        {
            W2e = 1;
            W2class = 1;
            PlayerPrefs.SetInt("W2E", W2e);
            PlayerPrefs.SetInt("W2CLASS", W2class);
            W2BTN.SetActive(false);
            weapon002.SetActive(true);
            weapon002.GetComponent<Animator>().runtimeAnimatorController = weaponClass[0];

        }
        else if (WNUM == 3)
        {
            W3e = 1;
            W3class = 1;
            PlayerPrefs.SetInt("W3E", W3e);
            PlayerPrefs.SetInt("W3CLASS", W3class);
            W3BTN.SetActive(false);
            weapon003.SetActive(true);
            weapon003.GetComponent<Animator>().runtimeAnimatorController = weaponClass[0];
        }
        else if (WNUM == 4)
        {
            W4e = 1;
            W4class = 1;
            PlayerPrefs.SetInt("W4E", W4e);
            PlayerPrefs.SetInt("W4CLASS", W4class);
            W4BTN.SetActive(false);
            weapon004.SetActive(true);
            weapon004.GetComponent<Animator>().runtimeAnimatorController = weaponClass[0];
        }
    }

}
