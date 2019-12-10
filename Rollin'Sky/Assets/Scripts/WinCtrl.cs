using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCtrl : MonoBehaviour
{
    public GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (WinTIle.stageClear)
        {
            Time.timeScale = 0f;
            deathUI.SetActive(true);
        }
    }

    public void nextStage()
    {
        Time.timeScale = 1f;
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene+1);
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menus");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Exit Completed");
        Application.Quit();
    }
}
