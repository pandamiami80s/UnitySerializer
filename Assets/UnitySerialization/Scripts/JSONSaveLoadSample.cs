using System.Collections.Generic;
using UnityEngine;

public class JSONSaveLoadSample : MonoBehaviour
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
        public Vector3 position;
    }
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
        Level level = new Level();

        // Walls
        level.walls = new List<Wall>();
        for (int i = 0; i < 4; i++)
        {
            Wall wall = new Wall();
            wall.name = "JSON Wall " + i.ToString();
            wall.size = 1.0f;

            level.walls.Add(wall);
        }

        // Floors
        level.floors = new List<Floor>();
        for (int i = 0; i < 2; i++)
        {
            Floor floor = new Floor();
            floor.id = i;
            floor.position = new Vector3(0, i, 0);

            level.floors.Add(floor);
        }

        JSONSerializer.Serialize(level, "Level");
    }



    void Load()
    {
        Level level = JSONSerializer.Deserialize<Level>("Level");

        Debug.Log("JSON file contains: " + level.walls[0].name + 
            ", Walls count: " + level.walls.Count + 
            ", Floors count: " + level.floors.Count);
    }
}