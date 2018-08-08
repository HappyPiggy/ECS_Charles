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
    Vector2 rotation { get; }

    ulong id { get; }
    Transform objTransform { get; }

    void OnDestroyedView(GameEntity entity);
    void Link(IContext context, IEntity entity); //链接gameobject和entity

}