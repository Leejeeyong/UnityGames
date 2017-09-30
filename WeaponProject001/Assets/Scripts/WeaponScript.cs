using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {
    static int W1e;
    static int W2e;
    static int W3e;
    static int W4e;

    //무기슬롯 버튼
    public GameObject W1BTN;
    public GameObject W2BTN;
    public GameObject W3BTN;
    public GameObject W4BTN;
    //무기 슬롯 이미지
    public GameObject W1SPI;
    public GameObject W2SPI;
    public GameObject W3SPI;
    public GameObject W4SPI;
    //무기 이미지
    public Sprite weapon001;
    public Sprite weapon002;

    

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("W1E", 0);
        PlayerPrefs.SetInt("W2E", 0);
        PlayerPrefs.SetInt("W3E", 0);
        PlayerPrefs.SetInt("W4E", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void checkWeapon(int WNUM)
    {

    }

    public void BuyWeapon(int WNUM)
    {
        if (WNUM == 1)
        {

            W1BTN.SetActive(false);
            W1e = 1;
            PlayerPrefs.SetInt("W1E", W1e);
            W1SPI.SetActive(true);

        }
        else if (WNUM == 2)
        {
            W2BTN.SetActive(false);
            W2e = 1;
            PlayerPrefs.SetInt("W2E", W2e);
            W2SPI.SetActive(true);

        }
        else if (WNUM == 3)
        {
            W3BTN.SetActive(false);
            W3e = 1;
            PlayerPrefs.SetInt("W3E", W3e);
        }
        else if (WNUM == 4)
        {
            W4BTN.SetActive(false);
            W4e = 1;
            PlayerPrefs.SetInt("W4E", W4e);
        }
    }
}
