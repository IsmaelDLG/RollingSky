using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelCtl : MonoBehaviour
{
    private System.Random rand;
    public string path = "/LevelMap/Level1.txt";//"/Scripts/LevelMap/test_0.txt";
    public GameObject cam;
    

    public List<GameObject> tiles;
    public List<GameObject> variants;
    public List<GameObject> obstacles;
    public List<GameObject> objOnScreen;

    string[][] level;
    int currentRow;
    // Start is called before the first frame update

    void Start()
    {
        rand = new System.Random();
        int nivell = SceneManager.GetActiveScene().buildIndex;
        String levelpath = "/LevelMap/Level" + nivell.ToString() + ".txt";
        this.transform.SetPositionAndRotation(new Vector3(0.0f,0.0f,0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        //Llegeixo el meu nivell
        string mypath = Application.streamingAssetsPath + levelpath;
        string file = File.ReadAllText(mypath);
        file = file.Replace("\r\n", "");
        string [] lvlRows = file.Split(';');
        int count = 0;
        level = new string[lvlRows.Length][];
        currentRow = 0;
        foreach(string row in lvlRows)
        {
           level[count] = row.Split(',');
           count++;
        }
        GameObject myTile = null;
        //Carrego els tiles disponibles
        for (int it = 0; it < 99 ; it++)
        {
            //find returns null if it couldn't find the obstacle
            myTile = GameObject.Find("Tile_" + it.ToString());
            tiles.Add(myTile);
        }

        //Carrego ls variants de tiles disponibles
        for (int it = 0; it < 20; it++)
        {
            //find returns null if it couldn't find the obstacle
            myTile = GameObject.Find("Variant_" + it.ToString());
            variants.Add(myTile);
        }

        //Carrego els obstacles disponibles
        GameObject myObstacle = new GameObject();
        //5 tiles diferents per cada nivell
        for (int it = 0; it < 99; it++)
        {
            //find returns null if it couldn't find the obstacle
            myObstacle = GameObject.Find("Obstacle_" + it.ToString());
            obstacles.Add(myObstacle);
        }
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    //5 obstacles diferents per cada nivell
    void Update()
    {
        //create objects
        if (currentRow < level.Length)
        {
            while (inViewRange(currentRow)) {
                for (int j = 0; j < level[currentRow].Length; j++)
                {
                    //create tile
                    int tile_id = level[currentRow][j][0] - '0';
                    if (tile_id != 0)
                    {
                        GameObject obj = null;
                        if (tile_id == 1)
                        {
                            if(rand.Next(10)>6)
                            {
                                int variant_id = rand.Next(1, 6);
                                obj = (GameObject)Instantiate(variants[variant_id-1],
                                    new Vector3(level[currentRow].Length / (-2.0f) + j, 1,
                                    currentRow), transform.rotation);
                            }
                            else
                            {
                                obj = (GameObject)Instantiate(variants[0],
                                    new Vector3(level[currentRow].Length / (-2.0f) + j, 1,
                                    currentRow), transform.rotation);
                            }
                            
                        }
                        else
                        {
                            obj = (GameObject)Instantiate(tiles[tile_id - 1],
                                new Vector3(level[currentRow].Length / (-2.0f) + j, 1,
                                currentRow), transform.rotation);
                        }
                        obj.transform.parent = transform;
                        objOnScreen.Add(obj);
                        //per carregar l'obstacle del tile

                        if (level[currentRow][j].Length > 2 && level[currentRow][j][1] == '.')
                        {
                            int obs_id = level[currentRow][j][2] - '0';
                            GameObject obs;
                            if (obs_id == 4)
                            {                                
                                obs = (GameObject)Instantiate(obstacles[obs_id - 1],
                                new Vector3(level[currentRow].Length / (-2.0f) + j, 2f, currentRow),
                                new Quaternion (transform.rotation.x, -1.0f, transform.rotation.z, transform.rotation.w));
                            }
                            else
                            {
                                obs = (GameObject)Instantiate(obstacles[obs_id - 1],
                                new Vector3(level[currentRow].Length / (-2.0f) + j, 2f, currentRow),
                                transform.rotation);
                            }
                            obs.transform.parent = transform;

                            objOnScreen.Add(obs);
                        }
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

        float zNear = 2.0f;
        float zFar = 17.5f;

        return (zPos >= cam.transform.position.z + zNear) && (zPos < cam.transform.position.z + zFar);
    }
}
