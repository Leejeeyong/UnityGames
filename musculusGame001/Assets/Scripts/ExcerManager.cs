using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcerManager : MonoBehaviour {
    public Text ExcerAtxt;
    public Text ExcerAbtnText;
    static int ExcerALV;
    static int ExcerAGetG;
    static int ExcerAPayH;
    static int gold;
    static int HP;
    int timespan;

    // Use this for initialization
    void Start () {
        HP = PlayerPrefs.GetInt("HP");
        gold = PlayerPrefs.GetInt("GOLD");
        ExcerALV = PlayerPrefs.GetInt("EXCERALV", 0);
        ExcerAGetG= PlayerPrefs.GetInt("EXCERGETGOLD", 5);
        ExcerAPayH= PlayerPrefs.GetInt("EXCERPAYHP", 30);
        ExcerAtxt.text = "LV:" + ExcerALV + "\n소요시간: " +(5+(5*ExcerALV))+ "\n획득골드: " + ExcerAGetG + "\n소요체력: " + ExcerAPayH;
    }
	
	// Update is called once per frame
	void Update () {
        //ExcerAtxt.text = "LV:" + ExcerALV + "\n소요시간(초): " + (5 + (5 * ExcerALV)) + "\n획득골드: " + ExcerAGetG + "\n소요체력: " + ExcerAPayH;
        if (timespan > 0)
        {
            ExcerAbtnText.text = timespan + "초";
        }
        else
        {
            ExcerAbtnText.text ="A";
        }
    }

    void saveData()
    {
        PlayerPrefs.SetInt("HP", HP);
        PlayerPrefs.SetInt("GOLD", gold);
        PlayerPrefs.SetInt("EXCERALV", ExcerALV);
        PlayerPrefs.SetInt("EXCERGETGOLD", ExcerAGetG);
        PlayerPrefs.SetInt("EXCERPAYHP", ExcerAPayH);
    }

    public void ExcerABtn()
    {
        if(HP<ExcerAPayH || timespan>0)
        {
            ExcerAtxt.text = "LV:" + ExcerALV + "\n소요시간: " + (5 + (5 * ExcerALV)) + "\n획득골드: " + ExcerAGetG + "\n소요체력: " + ExcerAPayH+"\nㄴㄴ";
        }
        else
        {
            timespan = (5 + (5 * ExcerALV));
            HP = HP - ExcerAPayH;
            saveData();
            StartCoroutine("Timer");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);

        timespan--;

        if (timespan == 0)
        {
            gold = gold + ExcerAGetG;
            ExcerALV++;
            ExcerAGetG = ExcerAGetG * 3 / 2;
            if (ExcerALV % 5 == 0)
            {
                ExcerAPayH++;
            }
            saveData();

        }
        else
        {
            StartCoroutine("Timer");
        }
    }

}
