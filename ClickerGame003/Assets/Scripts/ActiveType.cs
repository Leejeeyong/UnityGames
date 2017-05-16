using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveType : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IDragHandler {

    public static Vector2 defaultposition;
    public string type;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //Instantiate(gameObject, this.transform.position, this.transform.rotation);

        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos,Vector2.zero);

        if (rayhit.collider != null)
        {
            ScheduleCircle schedulecircle = rayhit.collider.gameObject.GetComponent<ScheduleCircle>();
            ScheduleManger.schedule[schedulecircle.num] = type;
        }

        this.transform.position = defaultposition;
    }

}
