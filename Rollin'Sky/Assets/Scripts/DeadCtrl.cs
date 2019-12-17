using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCtrl : MonoBehaviour
{
    private float timer;
    private GameObject player;
    public GameObject deathUI;
    public static bool deathMenuActive;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ball");
        deathMenuActive = false;
        timer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerMove>().isDead)
        {
            if (timer <= 0)
            {
                Time.timeScale = 0f;
                deathUI.SetActive(true);
                deathMenuActive = true;
            }
            else
            {
                timer -= Time.deltaTime;
            }
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
