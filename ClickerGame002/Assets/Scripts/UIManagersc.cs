using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagersc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClick(string type)
    {
        switch (type)
        {
            case "Start":
                SceneManager.LoadScene("Main");
                break;
            case "Continue"://데이터컨트롤 스크립트 이용해서

                break;
            case "Credit"://팝업창으로

                break;
        }
    }
}
