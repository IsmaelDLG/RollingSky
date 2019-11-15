using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelCtl : MonoBehaviour
{
    public const string path = "/LevelMap/test_0.txt";//"/Scripts/LevelMap/test_0.txt";
    public GameObject cam;


    public List<GameObject> tiles;
    public List<GameObject> obstacles;
    public List<GameObject> objOnScreen;

    string[][] level;
    int currentRow;
    // Start is called before the first frame update

    void Start()
    {
        this.transform.SetPositionAndRotation(new Vector3(0.0f,0.0f,0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        //Llegeixo el meu nivell
        string mypath = Application.streamingAssetsPath + path;
        string file = File.ReadAllText(mypath);
        string [] lvlRows = file.Split(';');
        int count = 0;
        level = new string[lvlRows.Length][];
        foreach(string row in lvlRows)
        {
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
        //create objects
        if (currentRow < level.Length)
        {
            while (inViewRange(currentRow)) {
                for (int j = 0; j < 5; j++)
                {
                    //crate tile
                    int tile = level[currentRow][j][0] - '0';
                    if (tile != 0)
                    {
                        GameObject obj = (GameObject)Instantiate(tiles[tile-1], new Vector3(level[currentRow].Length/(-2.0f)+j, 1, currentRow), transform.rotation);
                        obj.transform.parent = transform;
                        objOnScreen.Add(obj);
                    }
                    //create obstacle
                    //to be done...
                }
                currentRow++;
            }
        }

        //delete objects
        while (objOnScreen.Count > 0 && !inViewRange(objOnScreen[0].transform.position.z))
        {
            GameObject.Destroy(objOnScreen[0]);
            objOnScreen.RemoveAt(0);
        }
            
    }

    bool inViewRange(float zPos)
    {

        float zNear = 0.3f;
        float zFar = 17.5f;

        return (zPos >= cam.transform.position.z + zNear) && (zPos < cam.transform.position.z + zFar);
    }
}
