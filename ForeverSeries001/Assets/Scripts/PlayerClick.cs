using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    BoxCollider2D boxclollider;
    public SrarManager statManager;
    public GameObject Player;
    int count;

    // Use this for initialization
    void Start()
    {
        boxclollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (rayhit.collider != null)
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0) && SrarManager.ActiveUI == false)
            {
                statManager.getGold(SrarManager.clickpergold);//클릭할때마다 골드획득
                statManager.saveData();//골드양을 데이터에 저장

                Player.transform.localScale += new Vector3(1, 1, 0);


                Debug.Log("Player Click");
            }
            if (Input.GetMouseButtonUp(0))
            {
                Player.transform.localScale -= new Vector3(1, 1, 0);
            }
        }
    }
}
