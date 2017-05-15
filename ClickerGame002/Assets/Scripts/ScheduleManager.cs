using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManager : MonoBehaviour {

    public static int year;
    public static int month;

    // Use this for initialization
    void Awake () {
        year = 2017;
        month = 7;
        StartCoroutine("Timer");
    }
	
	// Update is called once per frame
	void Update () {

        Text[] mainCost = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();

        mainCost[6].text = year+"년"+month+"월";

    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);

        if(month == 12)
        {
            year++;
            month = 1;
        }
        else
        {
            month++;
        }

        StartCoroutine("Timer");
    }
}
