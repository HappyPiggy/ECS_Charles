using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 游戏地图的view
/// </summary>
public class MapView : BaseView
{
    private GameObject border;
    private BoxCollider2D[] borderBoxes;

    public void Start()
    {
       // InitBorder();
    }



    /// <summary>
    /// 初始化地图边界
    /// </summary>
    //private void InitBorder()
    //{
    //    border = transform.Find("border").gameObject;
    //    borderBoxes = border.transform.GetComponentsInChildren<BoxCollider2D>();

    //    Vector3 upBorderPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
    //    borderBoxes[0].transform.position = upBorderPos + new Vector3(0, 0.5f, 0); ;
    //    float width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x * 2;
    //    borderBoxes[0].size = new Vector2(width, 1);
    //}
}