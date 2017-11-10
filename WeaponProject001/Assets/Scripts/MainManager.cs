using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public BoxCollider2D boxclollider;//클릭영역부분
    public GameObject Enemy;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
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

    static int EnemyHP;

    public Text atkText1;
    public Text atkText2;
    public Text atkText3;
    public Text atkText4;



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

        atkText1.text = "ATK" + W1atk;
        atkText2.text = "ATK" + W2atk;
        atkText3.text = "ATK" + W3atk;
        atkText4.text = "ATK" + W4atk;


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        

        if (state==0)
        {
            //애니메이션 작동 1회만 실행
            weapon001.GetComponent<Animator>().Play("Base Layer.state_idle",1);
            weapon002.GetComponent<Animator>().Play("Base Layer.state_idle", 1);
            weapon003.GetComponent<Animator>().Play("Base Layer.state_idle", 1);
            weapon004.GetComponent<Animator>().Play("Base Layer.state_idle", 1);
        }
        else
        {
            state = 0;
        }

        if (rayhit.collider != null)//전체 화면에 충돌없지 않다면
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0))//지정공간 충돌과 눌러질때
            {
                if (W1e == 1)//1번째 활성화시 작동
                {
                    weapon001.GetComponent<Animator>().Play("Base Layer.state_shoot");
                    state = 1;
                    shootBull = Instantiate(bullet1, weapon001.transform.position + new Vector3(0.8f, 0.3f, 0), bullet1.transform.rotation) as GameObject;
                    shootBull.name = bullet1.name + "_" + Time.time;
                    //Debug.Log("HP" + EnemyHP);
                }
                if (W2e == 1)//2번째 활성화시 작동
                {
                    weapon002.GetComponent<Animator>().Play("Base Layer.state_shoot");
                    state = 1;
                    shootBull = Instantiate(bullet2, weapon002.transform.position + new Vector3(0.8f, 0.3f, 0), bullet2.transform.rotation) as GameObject;
                    shootBull.name = bullet2.name + "_" + Time.time;
                    //Debug.Log("HP" + EnemyHP);
                }
                if (W3e == 1)//3번째 활성화시 작동
                {
                    weapon003.GetComponent<Animator>().Play("Base Layer.state_shoot");
                    state = 1;
                    shootBull = Instantiate(bullet3, weapon003.transform.position + new Vector3(0.8f, 0.3f, 0), bullet3.transform.rotation) as GameObject;
                    shootBull.name = bullet3.name + "_" + Time.time;
                    //Debug.Log("HP" + EnemyHP);
                }
                if (W4e == 1)//4번째 활성화시 작동
                {
                    weapon004.GetComponent<Animator>().Play("Base Layer.state_shoot");
                    state = 1;
                    shootBull = Instantiate(bullet4, weapon004.transform.position + new Vector3(0.8f, 0.3f, 0), bullet4.transform.rotation) as GameObject;
                    shootBull.name = bullet4.name + "_" + Time.time;
                    //Debug.Log("HP" + EnemyHP);
                }
                Debug.Log("HP" + EnemyHP);
            }
        }

        EnemyHP = PlayerPrefs.GetInt("ENEMYHP");//적의 hp처리

    }

    void checkWeapon()//게임 시작시 슬롯 활성화 유무 확인과 활성화or비활성화
    {

        if (W1e == 1)
        {
            W1BTN.SetActive(false);
            weapon001.SetActive(true);
            weapon001.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W1class-1];

        }
        else
        {
            W1BTN.SetActive(true);
            weapon001.SetActive(false);
        }
        if (W2e == 1)
        {
            W2BTN.SetActive(false);
            weapon002.SetActive(true);
            weapon002.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W2class - 1];

        }
        else
        {
            W2BTN.SetActive(true);
            weapon002.SetActive(false);
        }
        if (W3e == 1)
        {
            W3BTN.SetActive(false);
            weapon003.SetActive(true);
            weapon003.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W3class - 1];

        }
        else
        {
            W3BTN.SetActive(true);
            weapon003.SetActive(false);
        }
        if (W4e == 1)
        {
            W4BTN.SetActive(false);
            weapon004.SetActive(true);
            weapon004.GetComponent<Animator>().runtimeAnimatorController = weaponClass[W4class - 1];

        }
        else
        {
            W4BTN.SetActive(true);
            weapon004.SetActive(false);
        }
    }

    public void Reset()//모든값 초기화
    {
        PlayerPrefs.SetInt("ENEMYHP", 100);
        PlayerPrefs.SetInt("W1ATK", 1);
        PlayerPrefs.SetInt("W2ATK", 2);
        PlayerPrefs.SetInt("W3ATK", 3);
        PlayerPrefs.SetInt("W4ATK", 4);

        PlayerPrefs.SetInt("W1E",0);
        PlayerPrefs.SetInt("W2E", 0);
        PlayerPrefs.SetInt("W3E", 0);
        PlayerPrefs.SetInt("W4E", 0);

        PlayerPrefs.SetInt("W1CLASS", 0);
        PlayerPrefs.SetInt("W2CLASS", 0);
        PlayerPrefs.SetInt("W3CLASS", 0);
        PlayerPrefs.SetInt("W4CLASS", 0);

        W1e = PlayerPrefs.GetInt("W1E");
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

    public void BuyWeapon(int WNUM)//슬롯활성화
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
