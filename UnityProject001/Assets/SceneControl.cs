using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour {
    private BlockRoot block_root = null;
	// Use this for initialization
	void Start () {
        //BlockRoot 스크립트를 가져온다
        this.block_root = this.gameObject.GetComponent<BlockRoot>();
        //BlockRoot 스크립트의 initialSetup()을 호출
        this.block_root.initialSetup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
