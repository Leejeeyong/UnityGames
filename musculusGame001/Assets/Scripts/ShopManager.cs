using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    public Text messageText;

    static int atk;
    static int def;
    static int HP;
    static int maxhp;
    static int gold;

    static int aGoldPay;

    // Use this for initialization
    void Start () {
        atk = PlayerPrefs.GetInt("ATK");
        def = PlayerPrefs.GetInt("DEF");
        HP = PlayerPrefs.GetInt("HP");
        gold = PlayerPrefs.GetInt("GOLD");
        aGoldPay = PlayerPrefs.GetInt("AGOLDPAY",100);

        messageText.text = "강화비용" + aGoldPay;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void saveData()
    {
        PlayerPrefs.SetInt("ATK", atk);
        PlayerPrefs.SetInt("DEF", def);
        PlayerPrefs.SetInt("HP", HP);
        PlayerPrefs.SetInt("GOLD", gold);
        PlayerPrefs.SetInt("AGOLDPAY", aGoldPay);
    }

    public void ATKUP()
    {
        if (gold >= aGoldPay)
        {
            gold = gold - aGoldPay;
            aGoldPay = aGoldPay + 2;
            messageText.text = "강화비용"+aGoldPay;
            atk = atk + 1;
            saveData();
        }
        else
        {
            messageText.text = "강화비용" + aGoldPay+"\n돈부족";
        }
    }
}
