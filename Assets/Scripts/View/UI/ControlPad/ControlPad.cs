using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPad : AppModule, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    private Vector2 curPoint = Vector2.zero;
    private Vector2 oldPoint = Vector2.zero;

    private static Vector2 direction = Vector2.zero;
    private static bool isMove = false;
    public static Vector2 Direction
    {
        get
        {
            return direction;
        }

    }

    public static bool IsMove
    {
        get
        {
            return isMove;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isMove = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
        isMove = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        InputUpdate();
    }

    /// <summary>
    /// 每一帧获取玩家输入到controlPad 转换成屏幕的坐标
    /// </summary>
    private void InputUpdate()
    {
        curPoint = Input.mousePosition;
        if (isMove)
        {
            direction = (curPoint - oldPoint).normalized;
            oldPoint = curPoint;
           // Debug.Log("dir "+direction);
        }

    }
}
