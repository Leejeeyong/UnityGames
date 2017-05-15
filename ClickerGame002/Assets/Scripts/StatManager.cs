using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

    public static int gold;//1st 재화
    public static int follower;//2nd 재화

    public static int condition;//hp
    public static int cMAX = 100;//컨디션 max값
    public static int mental;//mp
    public static int mMax = 100;//멘탈 max값

    public static int msSkill;//마우스스킬
    public static int kbSkill;//키보드스킬
    public static int opSkill;//운영스킬


    // Use this for initialization
    void Awake () {
        gold = 1000;
        follower = 1;
        condition = cMAX;
        mental = mMax;
        msSkill = 0;
        kbSkill = 0;
        opSkill = 0;

    }
	
	// Update is called once per frame
	void Update () {
        Text[] mainCost = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Text>();

        mainCost[4].text = "Money : "+gold;
        mainCost[5].text = "Follower : " + follower;
    }
}
