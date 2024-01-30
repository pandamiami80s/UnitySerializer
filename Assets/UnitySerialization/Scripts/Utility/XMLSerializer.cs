using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// 2024 01 30
/// </summary>

public class XMLSerializer
{
    // Windows 10: C:\Users\USER_NAME\AppData\LocalLow\DEDAULT_COMPANY\PROJECT_NAME
    static readonly string filePath = Application.persistentDataPath;
    static readonly string fileExtention = ".xml";

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
        StreamWriter streamWriter = new StreamWriter(pathCombine);
        XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());
        xmlSerializer.Serialize(streamWriter.BaseStream, item);
        streamWriter.Close();

        //Debug.Log("XML Serialize: " + pathCombine);
    }

    public static T Deserialize<T>(string fileName)
    {
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        StreamReader streamReader = new StreamReader(pathCombine);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        T item = (T)xmlSerializer.Deserialize(streamReader.BaseStream);
        streamReader.Close();

        //Debug.Log("XML Deserialize: " + pathCombine);

        return item;
    }
}
