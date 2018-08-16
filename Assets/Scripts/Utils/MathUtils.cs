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
            //var lookRotation = vector.normalized;
            //var dir = new Vector3(lookRotation.x, 0, lookRotation.y);
            //rotation = Quaternion.LookRotation(dir, -Vector3.up);
            float angle = Mathf.Atan2(vector.y,vector.x);
            Vector2 eulerAngles = rotation.eulerAngles;
            eulerAngles.y = angle * Mathf.Rad2Deg - 90;
            rotation.eulerAngles = eulerAngles;
        }

        
        return rotation;
    }

    /// <summary>
    /// 生成随机float
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int RandomInt(int min,int max)
    {
       return  UnityEngine.Random.Range(min, max);
    }

    public static float RandomFloat(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}