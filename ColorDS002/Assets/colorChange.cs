using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colorChange : MonoBehaviour {
    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;

    public GameObject colorBox;

    public int num=0;
    public int[] stack=new int[1000];

    valueChange Score;

    Color[] baseColor = {Color.red, Color.green, Color.blue, Color.yellow};
    int randomSeed;

	// Use this for initialization
	void Start () {
        //valueChange의 점수를 찾아 Score에 저장
        Score = GameObject.FindObjectOfType<valueChange>();

        randomSeed = Random.Range(0, 4);

        colorBox.transform.GetComponent<SpriteRenderer>().color = baseColor[randomSeed];
        num++;
        stack[num] = randomSeed;
        num++;

        //colorBox.transform.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void RClicked()
    {
        Debug.Log("RED");
    }
    public void GClicked()
    {
        Debug.Log("GREEN");
    }
    public void BClicked()
    {
        Debug.Log("BLUE");
    }
    public void YClicked()
    {
        Debug.Log("YELLOW");
    }
	

    public void boxChange()
    {
        StartCoroutine("boxChangebefore");

        randomSeed = Random.Range(0, 4);

        colorBox.transform.GetComponent<SpriteRenderer>().color = baseColor[randomSeed];

        stack[num] = randomSeed;
        num++;

    }

    IEnumerator boxChangebefore()
    {
        for(int i = 0; i <= num; i++)
        {
            colorBox.transform.GetComponent<SpriteRenderer>().color = baseColor[stack[i]];
            yield return new WaitForSeconds(1.0f);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
