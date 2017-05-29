using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubUIManager : MonoBehaviour {
    public SrarManager statm;
    public GameObject exerUI;
    public GameObject StatUI;
    public GameObject invenUI;
    public GameObject questUI;

    public static int askillplus;
    public static int aleve;
    public static int aspengold;

    public static int bskillplus;
    public static int bleve;
    public static int bspengold;

    public static int cskillplus;
    public static int cleve;
    public static int cspengold;

    // Use this for initialization
    void Start () {
       PlayerPrefs.SetInt("Blevel", 1);
        PlayerPrefs.SetInt("Bspend", 1);
        PlayerPrefs.SetInt("Bplus", 1);
        PlayerPrefs.SetInt("Alevel", 1);
        PlayerPrefs.SetInt("Aspend", 1);
        PlayerPrefs.SetInt("Aplus", 1);

        askillplus = PlayerPrefs.GetInt("Aplus", 1);
        aleve = PlayerPrefs.GetInt("Alevel", 1);
        aspengold = PlayerPrefs.GetInt("Aspend", 1);

        bskillplus = PlayerPrefs.GetInt("Bplus", 1);
        bleve = PlayerPrefs.GetInt("Blevel",1);
        bspengold = PlayerPrefs.GetInt("Bspend",1);

        cskillplus = PlayerPrefs.GetInt("Clevel",1);
        cleve = PlayerPrefs.GetInt("Cspend",1);
        cspengold = PlayerPrefs.GetInt("Cplus",1);
        exerUI.gameObject.SetActive(false);
        StatUI.gameObject.SetActive(true);
        invenUI.gameObject.SetActive(false);
        questUI.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (StatUI.activeSelf == true)
        {
            Text[] StatText = GameObject.FindGameObjectWithTag("StatUI").GetComponentsInChildren<Text>();

            StatText[0].text = "클릭당 골드 : " + SrarManager.clickpergold;
            StatText[1].text = "X능력 : " + SrarManager.Xabil;
            StatText[2].text = "Y능력 : " + SrarManager.Yabil;
            StatText[3].text = "Z능력 : " + SrarManager.Zabil;
        }
        if (exerUI.activeSelf == true)
        {
            Text[] ExerText = GameObject.FindGameObjectWithTag("ExerUI").GetComponentsInChildren<Text>();

            ExerText[3].text = "레벨 : " + aleve + "  비용 : " + aspengold + "  다음강화후 : " + (SrarManager.clickpergold + askillplus);
            ExerText[4].text = "레벨 : " + bleve + "  비용 : " + bspengold + "  다음강화후 : " + (SrarManager.secondpergold + bskillplus+bleve);
        }

    }


    public void ClickSubUIBtn(int num)
    {
        if (num == 0)//statUI 표시
        {
            exerUI.gameObject.SetActive(false);
            StatUI.gameObject.SetActive(true);
            invenUI.gameObject.SetActive(false);
            questUI.gameObject.SetActive(false);
        }
        else if (num == 1)//exerUI표시
        {
            exerUI.gameObject.SetActive(true);
            StatUI.gameObject.SetActive(false);
            invenUI.gameObject.SetActive(false);
            questUI.gameObject.SetActive(false);
        }
        else if (num == 2)//exerUI표시
        {
            exerUI.gameObject.SetActive(false);
            StatUI.gameObject.SetActive(false);
            invenUI.gameObject.SetActive(true);
            questUI.gameObject.SetActive(false);
        }
        else if (num == 3)//exerUI표시
        {
            exerUI.gameObject.SetActive(false);
            StatUI.gameObject.SetActive(false);
            invenUI.gameObject.SetActive(false);
            questUI.gameObject.SetActive(true);
        }
    }



    public void ASkill()
    {
        if (SrarManager.gold >= aspengold)
        {
            SrarManager.gold = SrarManager.gold - aspengold;
            SrarManager.clickpergold = SrarManager.clickpergold + askillplus;
            aleve = aleve + 1;
            SrarManager.Xabil++;
            aspengold = (int)(aspengold * 2.5);
            askillplus = (int)((askillplus+aleve) * 1.1);

            PlayerPrefs.SetInt("Alevel", aleve);
            PlayerPrefs.SetInt("Aspend", aspengold);
            PlayerPrefs.SetInt("Aplus", askillplus);

            statm.saveData();
        }
    }

    public void BSkill()
    {
        if (SrarManager.gold >= bspengold)
        {
            SrarManager.gold = SrarManager.gold - bspengold;
            SrarManager.secondpergold = SrarManager.secondpergold + bskillplus+bleve;
            bleve = bleve + 1;
            SrarManager.Yabil++;
            bspengold = (int)(bspengold * 2.3);
            bskillplus = (int)(bskillplus * 1.8);

            PlayerPrefs.SetInt("Blevel", bleve);
            PlayerPrefs.SetInt("Bspend", bspengold);
            PlayerPrefs.SetInt("Bplus", bskillplus);

            statm.saveData();
        }
    }
    public void CSkill()
    {

    }
}
