using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
/// <summary>
/// 生成配置文件
/// </summary>
public class CreateAsset : Editor
{

    [MenuItem("Tools/CreateAsset/ConfigAsset")]
    static void Create()
    {

        ScriptableObject obj = CreateInstance<PlayerConfig>();
        if (!obj)
        {
            Debug.LogWarning("Obj not found");
            return;
        }

        var path = string.Format("Assets/Resources/Config/{0}.asset", (typeof(PlayerConfig).ToString()));
        AssetDatabase.CreateAsset(obj, path);
    }
}