using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour {

    BoxCollider2D boxclollider;

	// Use this for initialization
	void Start () {
        boxclollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (rayhit.collider != null)
        {
            if (rayhit.collider == boxclollider && Input.GetMouseButtonDown(0))
            {
                Debug.Log("PlayerClick");
            }
        }
    }
}
