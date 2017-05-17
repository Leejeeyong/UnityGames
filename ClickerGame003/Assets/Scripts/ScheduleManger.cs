using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManger : MonoBehaviour {
    //Button[] type = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Button>();
    public static int year;//
    public static int month;//60초==1달

    public static string[] schedule;

    int timespan;//초단위계산
    public static bool ActiveUI;//버튼클릭으로 ui창 띄울때 시간을 멈추기위한

	// Use this for initialization
	void Awake () {
        ActiveUI = false;
        year = 2017;
        month = 6;
        schedule = new string[4];
        timespan = 9;

        StartCoroutine("Timer");
	}
	
	// Update is called once per frame
	void Update () {
        Text[] textbox = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();

        textbox[6].text = year + "년" + month + "월";
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);

        //activui가 없을때 , 평상시
        if (!ActiveUI) {
            timespan++;
            if (timespan == 10){//60초마다 한 달씩
                if (month == 12){//12월이 지난다면
                    timespan = 0;//초 초기화
                    month = 1;
                    year++;
                }
                else{
                    timespan = 0;
                    month++;
                }
                ActiveUI = true;
            }

        }

        StartCoroutine("Timer");
    }

    public void confirmSchedule()
    {
        ActiveUI = false;
        
    }

}
