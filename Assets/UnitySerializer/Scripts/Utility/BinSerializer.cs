using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// 2024 01 30
/// </summary>

public class BinSerializer : MonoBehaviour
{
    // Windows 10: C:\Users\USER_NAME\AppData\LocalLow\DEDAULT_COMPANY\PROJECT_NAME
    static readonly string filePath = Application.persistentDataPath;
    static readonly string fileExtention = ".kmstr";



    public static bool IsFileExists(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        if (File.Exists(pathCombine))
        {
            return true;
        }

        return false;
    }

    public static void Serialize(object item, string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        FileStream fileStream = new FileStream(pathCombine, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, item);
        fileStream.Close();

        //Debug.Log("Bin Serialize: " + pathCombine);
    }

    public static T Deserialize<T>(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        FileStream fileStream = new FileStream(pathCombine, FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        T item = (T)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();

        //Debug.Log("Bin Deserialize: " + pathCombine);

        return item;
    }
}