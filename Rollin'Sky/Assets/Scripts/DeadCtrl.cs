using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCtrl : MonoBehaviour
{

    private GameObject player;
    public GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerMove>().isDead)
        {
            Time.timeScale = 0f;
            deathUI.SetActive(true);
        }
    }

    public void restart()
    {
        Time.timeScale = 1f;
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
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
