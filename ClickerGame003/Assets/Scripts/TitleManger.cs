using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickButton(string type)
    {
        switch (type)
        {
            case "START":
                Debug.Log("NewGame");
                SceneManager.LoadScene("Main");
                break;
            case "CONTINUE"://데이터컨트롤 스크립트 이용해서
                Debug.Log("Continue");
                SceneManager.LoadScene("Main");
                break;
            case "CREDIT"://팝업창으로

                break;
        }
    }
}
