using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueChange : MonoBehaviour {

    public float value = 0.0f;
    private Text StringValue;

	// Use this for initialization
	void Awake () {
        StringValue = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        StringValue.text = string.Format("{0:d10}", (int)value);
	}
}
