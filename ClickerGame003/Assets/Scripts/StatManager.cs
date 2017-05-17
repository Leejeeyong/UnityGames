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

    // Use this for initialization
    void Awake () {
        ClickperGold = PlayerPrefs.GetInt("ClickperGold",1); ;
        gold = PlayerPrefs.GetInt("Gold");
        follower = 10;
        condition = c_MAx;
        phySkill = 0;
        mentalSkill = 0;
        abc = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Text[] textbox = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();//ui쪽 text불러옴

        textbox[4].text = "Gold : "+gold;//골드텍스트
        textbox[5].text = "Follower : " + follower;//팔로워텍스트
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
                phySkill = phySkill + 1;
                Debug.Log(type + " : " + phySkill);
                break;
            case "mental":
                mentalSkill = mentalSkill + 1;
                Debug.Log(type + " : " + mentalSkill);
                break;
            case "abc":
                abc = abc + 1;
                follower = follower + 5;
                Debug.Log(type + " : " + abc);
                break;
        }
    }
}
