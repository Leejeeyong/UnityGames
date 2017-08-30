using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SrarManager : MonoBehaviour {
    public GameObject bar;

    public static int gold;
    public static int clickpergold=1;
    public static int secondpergold;

    public static int Askill;
    public static int Bskill;
    public static int Cskill;

    public static int Xabil;
    public static int Yabil;
    public static int Zabil;

    public static int year;
    public static int month;
    public static int timespan;

    public static bool ActiveUI=false;


    // Use this for initialization
    void Awake() {
        /*PlayerPrefs.SetInt("Gold", 1);
        PlayerPrefs.SetInt("Secondper", 1);
        PlayerPrefs.SetInt("Clickper", 1);
        PlayerPrefs.SetInt("Year", 2017);
<<<<<<< HEAD
        PlayerPrefs.SetInt("Month", 1);
        PlayerPrefs.SetInt("Secondper", 1);
        PlayerPrefs.SetInt("Clickper", 1);*/
=======
        PlayerPrefs.SetInt("Month", 1);*/
        PlayerPrefs.SetInt("Secondper", 1);
        PlayerPrefs.SetInt("Clickper", 1);
>>>>>>> 99b62f288b3fa006fbe5caebb0f9bf139eb37ff0

        gold = PlayerPrefs.GetInt("Gold");
        clickpergold = PlayerPrefs.GetInt("Clickper",1);
        secondpergold = PlayerPrefs.GetInt("Secondper",1);
        year = PlayerPrefs.GetInt("Year",2017);
        month = PlayerPrefs.GetInt("Month",1);
        Xabil = PlayerPrefs.GetInt("Xabil", 1);
        Yabil = PlayerPrefs.GetInt("Yabil", 1);
        Zabil = PlayerPrefs.GetInt("Zabil", 1);

        StartCoroutine("Timer");


    }
	
	// Update is called once per frame
	void Update () {
        Text[] Textbox = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();

        Textbox[4].text = ""+gold;
        Textbox[5].text = secondpergold+"/s";

        Text[] textbox = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();

        textbox[6].text = year + "년" + month + "월";
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);

        if (timespan == 10)
        {
            if (month >= 12)
            {
                year++;
                month = 1;
            }
            else
            {
                month++;
            }
            bar.transform.localPosition = new Vector3(-1,0.8f,0);
            bar.transform.localScale = new Vector3(2.8f,2.3f,0);
            timespan = 0;
        }

        if (ActiveUI == false)
        {
            getGold(secondpergold);
            saveData();
            timespan++;
            bar.transform.localScale -= new Vector3(0.28f, 0, 0);
            bar.transform.localPosition += new Vector3(0.0828f,0,0);
        }
        StartCoroutine("Timer");
    }

    public void getGold(int plus)
    {
        gold = gold + plus;
    }
    public void saveData()
    {
        PlayerPrefs.SetInt("Gold",gold);
        PlayerPrefs.SetInt("Secondper", secondpergold);
        PlayerPrefs.SetInt("Clickper", clickpergold);
        PlayerPrefs.SetInt("Year", year);
        PlayerPrefs.SetInt("Month", month);
    }

    
}


    
