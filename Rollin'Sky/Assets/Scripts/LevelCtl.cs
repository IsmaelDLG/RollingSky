using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelCtl : MonoBehaviour
{
    public const string path = "/Scripts/LevelMap/test_0.txt";
    public GameObject pc;

    public List<GameObject> tiles;
    public List<GameObject[]> obstacles;

    string[] level;
    int width;
    // Start is called before the first frame update
    void Start()
    {
        //Llegeixo el meu nivell
        string mypath = Application.dataPath + path;
        string file = File.ReadAllText(mypath);
        int rows = file.Split(';').Length;

        //Carrego els tiles disponibles
        GameObject myTile = new GameObject();
        for (int it = 0; myTile != null; it++)
        {
            //find returns null if it couldn't find the obstacle
            myTile = GameObject.Find("Tile_" + it.ToString());
            tiles.Add(myTile);
        }

        //Carrego els obstacles disponibles
        GameObject myObstacle = new GameObject();
        for (int it = 0; myObstacle != null; it++)
        {
            //find returns null if it couldn't find the obstacle
            myTile = GameObject.Find("Obstacle_" + it.ToString());
            tiles.Add(myTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
