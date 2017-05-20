using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour {

    BoxCollider2D boxclollider;
    public StatManager statManager;
    int count;

	// Use this for initialization
	void Start () {
        boxclollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
        int x=4;

        if (rayhit.collider != null)
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0) && ScheduleManger.ActiveUI == false)
            {
                statManager.getGold();//클릭할때마다 골드획득
                statManager.saveGold();//골드양을 데이터에 저장
                count++;

                for (int i = 0; i < 4; i++)
                {
                    if (ScheduleManger.schedule[i] =="phy" || ScheduleManger.schedule[i] == "mental" || ScheduleManger.schedule[i] == "abc")
                    {
                        statManager.useCondition();
                    }
                    if (count == 10)
                    {
                        statManager.getSkill(ScheduleManger.schedule[i]);
                    }
                }
                if (count == 10)
                    count = 0;
                Debug.Log("Player Click");
            }
        }
    }
}
