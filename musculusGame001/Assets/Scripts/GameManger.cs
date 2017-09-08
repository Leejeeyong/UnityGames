using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {
    static int myloc;
    static int atk;
    static int def;
    static int HP;
    static int maxhp;
    static int gold;
    static int a = 0;
    static int timespan;
    public GameObject upbtn;
    public GameObject downbtn;
    public GameObject BackGround;
    public Text atkText;
    public Text defText;
    public Text HPText;
    public Text GoldText;
    public Text nowlocText;
    public Canvas GameOverUI;


    static Vector3[] posBG = { new Vector3(-0.07f, -11f, 0), new Vector3(-0.07f, -1.4f, 0), new Vector3(-0.07f, 10f, 0) };

    void saveData()
    {
        PlayerPrefs.SetInt("ATK",atk);
        PlayerPrefs.SetInt("DEF",def);
        PlayerPrefs.SetInt("HP",HP);
        PlayerPrefs.SetInt("GOLD",gold);
    }
    void resetData()
    {
        PlayerPrefs.SetInt("ATK", 5);
        PlayerPrefs.SetInt("DEF", 2);
        PlayerPrefs.SetInt("HP", 100);
        PlayerPrefs.SetInt("GOLD", 1000);
        PlayerPrefs.SetInt("AGOLDPAY",1);
        PlayerPrefs.SetInt("AGOLDPAYLV", 0);
        PlayerPrefs.SetInt("EXCERALV", 0);
        PlayerPrefs.SetInt("EXCERGETGOLD", 5);
        PlayerPrefs.SetInt("EXCERPAYHP", 30);
    }
    public void Gameover()
    {
        resetData();
        GameOverUI.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start() {
        //resetData();
       

        timespan = 0;

        StartCoroutine("Timer");
        myloc = PlayerPrefs.GetInt("MYLOC",1);
        atk = PlayerPrefs.GetInt("ATK");
        def = PlayerPrefs.GetInt("DEF");
        HP = PlayerPrefs.GetInt("HP");
        gold=PlayerPrefs.GetInt("GOLD");

        
    }

    // Update is called once per frame
    void Update() {
        if (HP == 0)
        {
            GameOverUI.gameObject.SetActive(true);
        }

        if (myloc == 0)
        {
            upbtn.SetActive(false);
        }
        else if (myloc == 2)
        {
            downbtn.SetActive(false);
        }
        else
        {
            upbtn.SetActive(true);
            downbtn.SetActive(true);
        }

        if (BackGround.transform.position != posBG[myloc])
        {
            BackGround.transform.position = Vector3.Lerp(BackGround.transform.position, BackGround.transform.position + a * new Vector3(0, 0.1f, 0), 100.0f);
        }
        else
        {
            a = 0;
        }

        
        if (myloc == 2)
        {
            nowlocText.text = "심해";//hp--,gold+ 
        }
        else if (myloc == 1)
        {
            nowlocText.text = "수중";//0
        }
        else
        {
            nowlocText.text = "해수면";//hp++
        }

        atk = PlayerPrefs.GetInt("ATK");
        def = PlayerPrefs.GetInt("DEF");
        HP = PlayerPrefs.GetInt("HP");
        gold = PlayerPrefs.GetInt("GOLD");

        atkText.text = atk + "";
        defText.text = def + "";
        HPText.text = HP + "";
        GoldText.text = gold + "";
    }

    public void Uobtn()
    {

        if (myloc == 1)
        {
            myloc = myloc - 1;
            a = -1;
        }
        else
        {
            myloc = myloc - 1;
            a = -1;
        }
        timespan = 1;
        saveData();
    }
    public void Downbtn()
    {
        if (myloc == 1)
        {
            myloc = myloc + 1;
            a = 1;
        }
        else
        {
            a = 1;
            myloc = myloc + 1;
        }
        timespan = 1;
        saveData();
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);

        timespan++;
        if (timespan % 5 == 0)
        {
            if (myloc == 0)//해수면 일때
            {
                if (HP >= 98)
                {
                    HP = 100;
                }
                else
                {
                    HP = HP + 2;
                }
                saveData();
            }
            else if (myloc == 2)
            {
                if (HP > 1)
                {
                    HP = HP - 2;
                    gold++;
                }
                saveData();
            }
            else if (myloc == 1)
            {
                if (HP >= 99)
                {
                    HP = 100;
                }
                else
                {
                    HP = HP + 1;
                }
                saveData();
            }
        }
        StartCoroutine("Timer");
    }
    /// <summary>
    /// ShopUI
    /// </summary>
    public Canvas shopUI;
    public void Abtn()
    {
        if (shopUI.gameObject.active == false)
        {
            shopUI.gameObject.SetActive(true);
        }
        else
        {
            shopUI.gameObject.SetActive(false);

        }
    }
    public Canvas excerUI;
    public void Bbtn()
    {
        if (excerUI.gameObject.active == false)
        {
            excerUI.gameObject.SetActive(true);
        }
        else
        {
            excerUI.gameObject.SetActive(false);

        }
    }
}
