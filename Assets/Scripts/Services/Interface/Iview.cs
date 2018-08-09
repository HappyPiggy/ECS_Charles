using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IView
{
    Vector2 position { get; }
    Vector2 scale { get; }
    Quaternion rotation { get; }

    ulong uid { get; }
    Transform objTransform { get; } // 可以由此得到gameobject

    void OnDestroyedView();
    void Link(IContext context, IEntity entity); //链接gameobject和entity

}