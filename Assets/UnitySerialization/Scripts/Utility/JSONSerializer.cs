using UnityEngine;
using System.IO;

/// <summary>
/// 2022 09 15
/// </summary>

public class JSONSerializer
{
    // Windows 10: C:\Users\USER_NAME\AppData\LocalLow\DEDAULT_COMPANY\PROJECT_NAME
    static readonly string filePath = Application.persistentDataPath;
    static readonly string fileExtention = ".json";

    public static void Serialize(object item, string fileName)
    {
        string toJson = JsonUtility.ToJson(item, true);
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        File.WriteAllText(pathCombine, toJson);

        Debug.Log("JSON Serialize: " + pathCombine);
    }

    public static T Deserialize<T>(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        string fromJson = File.ReadAllText(pathCombine);
        T item = JsonUtility.FromJson<T>(fromJson);

        Debug.Log("JSON Deserialize: " + pathCombine);

        return item;
    }
}
