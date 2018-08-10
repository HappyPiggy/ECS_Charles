using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPad : AppModule,IPointerDownHandler,IDragHandler,IPointerUpHandler {

    private Vector2 oldPos = Vector2.zero;
    private static Vector2 direction = Vector2.zero;

    public static Vector2 Direction
    {
        get
        {
            return direction;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
      //  Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // direction = Vector2.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        direction = (eventData.position - oldPos).normalized;
        oldPos = eventData.position;
    }
}
