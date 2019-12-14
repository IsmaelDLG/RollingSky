using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseUI;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void loadMainMenu()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menus");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Completed");
        Application.Quit();
    }

    public void activateGod(bool state)
    {
        player.GetComponent<PlayerMove>().changeMode(state);
    }
}
