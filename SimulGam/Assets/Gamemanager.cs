using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gamemanager : MonoBehaviour
{
    public Camera MainCa;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
               
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                MainCa.transform.Translate(touch.position); // 이럴수가 !!!!!!!

            }
            else if (touch.phase == TouchPhase.Ended)
            {
            }
        }
    }
}
