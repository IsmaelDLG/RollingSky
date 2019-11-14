using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuControler : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("TestModel");
    }
}
