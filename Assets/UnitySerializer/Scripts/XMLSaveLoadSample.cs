using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// 2023 01 30
/// </summary>

public class XMLSaveLoadSample : MonoBehaviour
{
    public class Wall
    {
        public string name;
        public float size;
    }
    public class Floor
    {
        public int id;
        public Vector3 position;
    }
    public class Level
    {
        [XmlArray(ElementName = "Wall_list")]
        public List<Wall> walls;
        [XmlArray(ElementName = "Floor_list")]
        public List<Floor> floors;
    }



    void Start()
    {
        Save();

        Load();
    }

    void Save()
    {
        Level Level = new Level();
        // Walls
        Level.walls = new List<Wall>();
        for (int i = 0; i < 4; i++)
        {
            Wall wall = new Wall();
            wall.name = "XML Wall " + i.ToString();
            wall.size = 1.0f;

            Level.walls.Add(wall);
        }
        // Floors
        Level.floors = new List<Floor>();
        for (int i = 0; i < 2; i++)
        {
            Floor floor = new Floor();
            floor.id = i;
            floor.position = new Vector3(0, i, 0);

            Level.floors.Add(floor);
        }

        // Save
        XMLSerializer.Serialize(Level, "Level");
    }

    void Load()
    {
        Level level = XMLSerializer.Deserialize<Level>("Level");

        Debug.Log("XML file contains: " + level.walls[0].name +
            ", Walls count:  " + level.walls.Count +
            ", Floors count: " + level.floors.Count);
    }
}