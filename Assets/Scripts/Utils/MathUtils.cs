using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public  static class MathUtils
{
    /// <summary>
    ///  vector转rotation
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static Quaternion Vector2Quaternion(Vector2 vector)
    {
        Quaternion rotation=Quaternion.identity;
        if (vector != Vector2.zero) {
            var lookRotation = vector.normalized;
            var dir = new Vector3(lookRotation.x, 0, lookRotation.y);
            rotation = Quaternion.LookRotation(dir, -Vector3.up);
        }

        
        return rotation;
    }

}