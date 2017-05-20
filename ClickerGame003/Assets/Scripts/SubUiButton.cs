using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubUiButton : MonoBehaviour {
    public GameObject exerUI;
    public GameObject StatUI;
    public GameObject invenUI;
    public GameObject questUI;
    public GameObject[] ScheCir = new GameObject[4];

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        

        //여기부터 스케쥴 선택에따른 스케쥴서클의 색상변경
        for (int i = 0; i < 4; i++)
        {
            if (ScheduleManger.schedule[i] == "phy")
            {
                ScheCir[i].GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (ScheduleManger.schedule[i] == "mental")
            {
                ScheCir[i].GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (ScheduleManger.schedule[i] == "abc")
            {
                ScheCir[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if(ScheduleManger.schedule[i] == "slack")
            {
                ScheCir[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        //여기까지
		
	}

    public void ClickBtn(int num)
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
}
