using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelCtl : MonoBehaviour
{
    public const string path = "/Scripts/LevelMap/test_0.txt";
    public GameObject pc;

    string[] level;
    int width;
    // Start is called before the first frame update
    void Start()
    {
        string mypath = Application.dataPath + path;
        Debug.Log(mypath);
        /*using (var fileStream = new FileStream(@, FileMode.Open, FileAccess.Read))
        {
            // read from file
        }*/

    }

    // Update is called once per frame
    void Update()
    {
    }
}
