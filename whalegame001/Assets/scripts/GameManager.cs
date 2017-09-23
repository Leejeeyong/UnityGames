using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //능력치
    static int attack;
    static int gold;
    static int cri;
    static int crid;
    static int goldperclick;
    static int goldpersecond;
    //텍스트 출력
    public Text goldtxt;
    public Text atktxt;
    public Text critxt;
    public Text cridtxt;
    public Text goldperctxt;
    public Text goldperstxt;
    //클릭시스템
    public BoxCollider2D boxclollider;
    public GameObject ClickSectiopn;
    public GameObject Player;

    void resetData()
    {
        PlayerPrefs.SetInt("GOLD", 1000);
        PlayerPrefs.SetInt("ATTACK", 3);
        PlayerPrefs.SetInt("CRI", 10);
        PlayerPrefs.SetInt("CRID", 2);
        PlayerPrefs.SetInt("GOLDPERCLICK", 1);
        PlayerPrefs.SetInt("GOLDPERSECOND", 1);
    }

    void saveData()
    {
        PlayerPrefs.SetInt("GOLD", gold);
        PlayerPrefs.SetInt("ATTACK", attack);
        PlayerPrefs.SetInt("CRI", cri);
        PlayerPrefs.SetInt("CRID", crid);
        PlayerPrefs.SetInt("GOLDPERCLICK", goldperclick);
        PlayerPrefs.SetInt("GOLDPERSECOND", goldpersecond);
    }

	// Use this for initialization
	void Start () {
        //boxclollider = GetComponent<BoxCollider2D>();
        gold =PlayerPrefs.GetInt("GOLD", 1000);
        attack=PlayerPrefs.GetInt("ATTACK", 3);
        cri=PlayerPrefs.GetInt("CRI", 10);
        crid=PlayerPrefs.GetInt("CRID", 2);
        goldperclick= PlayerPrefs.GetInt("GOLDPERCLICK", 1);
        goldpersecond =PlayerPrefs.GetInt("GOLDPERSECOND", 1);

        StartCoroutine("Timer");
	}

    // Update is called once per frame
    void Update()
    {
        goldtxt.text = "" + gold;
        atktxt.text = "" + attack;
        critxt.text = "" + cri;
        cridtxt.text = "" + crid;
        goldperctxt.text = "" + goldperclick;
        goldperstxt.text = "" + goldpersecond;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (rayhit.collider != null)
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0))
            {
                gold = gold + goldperclick;
                saveData();//골드양을 데이터에 저장
                Player.transform.localScale += new Vector3(1, 1, 0);


                Debug.Log("Player Click");
            }
            if (Input.GetMouseButtonUp(0))
            {
                Player.transform.localScale -= new Vector3(1, 1, 0);
            }

        }


    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);

        gold = gold + goldpersecond;

        StartCoroutine("Timer");
    }
}
