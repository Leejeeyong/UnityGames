using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {
    public GameObject CreditUI;

	// Use this for initialization
	void Start () {
        CreditUI.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickStartBtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void ClickCreditBtn()
    {
        CreditUI.gameObject.SetActive(true);
    }
    public void ClickCreditCloseBtn()
    {
        CreditUI.gameObject.SetActive(false);
    }
}
