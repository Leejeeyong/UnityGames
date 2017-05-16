using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

    public static int gold;// 1 재화
    public static int follower;// 2 재화

    public static int condition;//hp
    public static int mental;//mp
    public static int c_MAx;//Max hp
    public static int m_MAX;//Max mp

    public static int phySkill;//피지컬 능력
    public static int operSkill;//운영 능력
    public static int abc;//미정

    // Use this for initialization
    void Awake () {
        gold = 1000;
        follower = 10;
        condition = c_MAx;
        mental = m_MAX;
        phySkill = 0;
        operSkill = 0;
        abc = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Text[] textbox = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();//ui쪽 text불러옴

        textbox[4].text = "Gold : "+gold;//골드텍스트
        textbox[5].text = "Follower : " + follower;//팔로워텍스트
	}
}
