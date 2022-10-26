/// <summary>
/// 2022 09 15
/// 
/// XML Serialize / Deserialize
/// </summary>

using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class XMLSerializer
{
    // Windows 10: C:\Users\USER_NAME\AppData\LocalLow\DEDAULT_COMPANY\PROJECT_NAME
    static readonly string filePath = Application.persistentDataPath;
    static readonly string fileExtention = ".xml";

    public static void Serialize(object item, string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        StreamWriter streamWriter = new StreamWriter(pathCombine);
        xmlSerializer.Serialize(streamWriter.BaseStream, item);
        streamWriter.Close();

        Debug.Log("XML Serialize: " + pathCombine);
    }

    public static T Deserialize<T>(string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        string pathCombine = Path.Combine(filePath, fileName + fileExtention);
        StreamReader streamReader = new StreamReader(pathCombine);
        T item = (T)xmlSerializer.Deserialize(streamReader.BaseStream);
        streamReader.Close();

        Debug.Log("XML Deserialize: " + pathCombine);

        return item;
    }
}
