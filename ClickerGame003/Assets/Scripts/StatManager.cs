using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

    public static int ClickperGold;

    public static int gold;// 1 재화
    public static int follower;// 2 재화

    public static int condition;//hp
    public static int c_MAx;//Max hp

    public static int phySkill;//피지컬 능력
    public static int mentalSkill;//멘탈 능력
    public static int abc;//미정

    GameObject exerUI;
    GameObject StatUI;
    GameObject invenUI;
    GameObject questUI;

    // Use this for initialization
    void Awake () {
        ClickperGold = PlayerPrefs.GetInt("ClickperGold",1); ;
        gold = PlayerPrefs.GetInt("Gold");
        follower = PlayerPrefs.GetInt("Follower");
        condition = PlayerPrefs.GetInt("Condition",100); ;
        phySkill = PlayerPrefs.GetInt("PHYskill");
        mentalSkill = PlayerPrefs.GetInt("MENTALskill");
        abc = PlayerPrefs.GetInt("ABCskill");

        exerUI = GameObject.Find("Exer UI");
        StatUI = GameObject.Find("Stat UI");
        invenUI = GameObject.Find("Inven UI");
        questUI = GameObject.Find("Quest UI");
        exerUI.gameObject.SetActive(false);//활동
        StatUI.gameObject.SetActive(true);//능력치
        invenUI.gameObject.SetActive(false);//가방
        questUI.gameObject.SetActive(false);//임무

        Text[] Stattextbox = GameObject.FindGameObjectWithTag("SubUI").GetComponentsInChildren<Text>();

        Stattextbox[0].text = "CON : " + condition;//여기부터 stat값들
        Stattextbox[1].text = "PHY : " + phySkill;
        Stattextbox[2].text = "M.T : " + mentalSkill;
        Stattextbox[3].text = "ABC : " + abc;//여기까지 stat값들
    }
	
	// Update is called once per frame
	void Update () {
        Text[] textbox = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();//ui쪽 text불러옴

        textbox[4].text = "Gold : "+gold;//골드텍스트
        textbox[5].text = "Follower : " + follower;//팔로워텍스트

        Text[] Stattextbox = GameObject.FindGameObjectWithTag("SubUI").GetComponentsInChildren<Text>();
        //여기부터 UI별로 표시할 텍스트를 결정

        if (StatUI.active == true)
        {
            Stattextbox[0].text = "CON : " + condition;//여기부터 stat값들
            Stattextbox[1].text = "PHY : " + phySkill;
            Stattextbox[2].text = "M.T : " + mentalSkill;
            Stattextbox[3].text = "ABC : " + abc;//여기까지 stat값들
        }
        else if (exerUI.active == true)
        {

        }
        else if (invenUI.active == true)
        {

        }
        else if (questUI.active == true)
        {

        }
        //여기까지

        if (condition >= 100)
        {
            condition = 100;
        }
        if (condition < 0)
        {
            condition = 0;
        }
    }

    public void saveGold()
    {
        PlayerPrefs.SetInt("Gold",gold);
    }

    public void getGold()
    {
        gold = gold + ClickperGold;
    }

    public void getSkill(string type)
    {
        switch (type)
        {
            case "phy":
                if (condition - 5 < 0)
                    break;
                phySkill = phySkill + 1;
                Debug.Log(type + " : " + phySkill);
                break;
            case "mental":
                if (condition - 5 < 0)
                    break;
                mentalSkill = mentalSkill + 1;
                Debug.Log(type + " : " + mentalSkill);
                break;
            case "abc":
                if (condition - 5 < 0)
                    break;
                abc = abc + 1;
                follower = follower + 5;
                Debug.Log(type + " : " + abc);
                break;
            default:
                condition = condition + 10;
                Debug.Log("null");
                break;
        }
        saveStat();
    }

    public void saveStat()
    {
        PlayerPrefs.SetInt("Follower", follower);

        PlayerPrefs.SetInt("Condition",condition);
        PlayerPrefs.SetInt("PHYskill",phySkill);
        PlayerPrefs.SetInt("MENTALskill",mentalSkill);
        PlayerPrefs.SetInt("ABCskill",abc);
    }

    public void useCondition()
    {
        condition = condition - 1;
        saveStat();
    }
}
