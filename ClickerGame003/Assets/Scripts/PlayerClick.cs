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

        if (rayhit.collider != null)
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0) && ScheduleManger.ActiveUI == false)
            {
                statManager.getGold();
                statManager.saveGold();
                count++;

                if (count == 10)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        statManager.getSkill(ScheduleManger.schedule[i]);
                    }
                    count = 0;
                    
                }
                Debug.Log("Player Click");
            }
        }
    }
}
