using System.IO;
using UnityEngine;

/// <summary>
/// 2024 01 30
/// </summary>

public class JSONSerializer
{
    // Windows 10: C:\Users\USER_NAME\AppData\LocalLow\DEDAULT_COMPANY\PROJECT_NAME
    static readonly string filePath = Application.persistentDataPath;
    static readonly string fileExtention = ".json";



    public static bool IsFileExists(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        if (File.Exists(pathCombine))
        {
            return true;
        }

        return false;
    }

    public static void RemoveFile(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        File.Delete(pathCombine);
    }

    public static void Serialize(object item, string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        string toJson = JsonUtility.ToJson(item, true);
        File.WriteAllText(pathCombine, toJson);

        //Debug.Log("JSON Serialize: " + pathCombine);
    }

    public static T Deserialize<T>(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        string fromJson = File.ReadAllText(pathCombine);
        T item = JsonUtility.FromJson<T>(fromJson);

        //Debug.Log("JSON Deserialize: " + pathCombine);

        return item;
    }
}