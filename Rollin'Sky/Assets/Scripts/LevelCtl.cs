using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelCtl : MonoBehaviour
{
    public const string path = "/Scripts/LevelMap/test_0.txt";
    public GameObject pc;
    public GameObject cam;


    public List<GameObject> tiles;
    public List<GameObject> obstacles;

    string[][] level;
    int currentRow;
    // Start is called before the first frame update

    void Start()
    {
        this.transform.SetPositionAndRotation(cam.transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        //Llegeixo el meu nivell
        string mypath = Application.dataPath + path;
        string file = File.ReadAllText(mypath);
        string [] lvlRows = file.Split(';');
        int count = 0;
        level = new string[lvlRows.Length][];
        foreach(string row in lvlRows)
        {
            Debug.Log(row);
           level[count] = row.Split(',');
           count++;
        }
        
        //Carrego els tiles disponibles
        GameObject myTile = new GameObject();
        for (int it = 0; it < 1 ; it++)
        {
            //find returns null if it couldn't find the obstacle
            myTile = GameObject.Find("Tile_" + it.ToString());
            tiles.Add(myTile);
        }

        //Carrego els obstacles disponibles
        GameObject myObstacle = new GameObject();
        for (int it = 0; it < 0; it++)
        {
            //find returns null if it couldn't find the obstacle
            myTile = GameObject.Find("Obstacle_" + it.ToString());
            tiles.Add(myTile);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRow < level.Length)
        {
            while (inViewRange()) {
                for (int j = 0; j < 5; j++)
                {
                    //get tile
                    int tile = level[currentRow][j][0] - '0';
                    if (tile != 0)
                    {
                        GameObject obj = (GameObject)Instantiate(tiles[tile-1], new Vector3(-2.50f+j, 1, currentRow), transform.rotation);
                        obj.transform.parent = transform;
                    }
                }
                currentRow++;
            }
        }
    }

    bool inViewRange()
    {

        float zNear = 0.3f;
        float zFar = 17.5f;

        return (currentRow >= cam.transform.position.z + zNear) && (currentRow < cam.transform.position.z + zFar);
    }
}
