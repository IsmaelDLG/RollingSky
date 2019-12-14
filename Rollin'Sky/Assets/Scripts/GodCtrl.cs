using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCtrl : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame

    void deactivateGodMode()
    {
        this.GetComponent<BoxCollider>().isTrigger = true;
    }

    void activateGodMode()
    {
        this.GetComponent<BoxCollider>().isTrigger = false;
    }
    void Update()
    {
        if(player.GetComponent<PlayerMove>().godMode)
        {
            activateGodMode();
        }
        else
        {
            deactivateGodMode();
        }
    }
}
