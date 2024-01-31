using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023 01 30
/// </summary>

public class BinSaveLoadSample : MonoBehaviour
{
    [System.Serializable]
    public class Wall
    {
        public string name;
        public float size;
    }
    [System.Serializable]
    public class Floor
    {
        public int id;
        public int positionX;
        public int positionY;
        public int positionZ;
    }
    [System.Serializable]
    public class Level
    {
        public List<Wall> walls;
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
            wall.name = "Bin Wall " + i.ToString();
            wall.size = 1.0f;

            Level.walls.Add(wall);
        }
        // Floors
        Level.floors = new List<Floor>();
        for (int i = 0; i < 2; i++)
        {
            Floor floor = new Floor();
            floor.id = i;
            floor.positionX = 0;
            floor.positionY = i;
            floor.positionZ = 0;

            Level.floors.Add(floor);
        }

        // Save
        BinSerializer.Serialize(Level, "Level");
    }

    void Load()
    {
        Level level = BinSerializer.Deserialize<Level>("Level");

        Debug.Log("Bin file contains: " + level.walls[0].name +
            ", Walls count:  " + level.walls.Count +
            ", Floors count: " + level.floors.Count);
    }
}