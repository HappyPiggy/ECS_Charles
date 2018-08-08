using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPad : AppModule,IPointerDownHandler,IDragHandler,IPointerUpHandler {




    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }
}
