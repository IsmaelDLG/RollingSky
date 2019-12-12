﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusciManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuController.IsPaused)
        {
            this.GetComponent<AudioSource>().volume = 0.005f;
        }
        else
        {
            this.GetComponent<AudioSource>().volume = 0.025f;
        }

        if (DeadCtrl.deathMenuActive)
        {
            this.GetComponent<AudioSource>().volume = 0.0025f;
        }
        else
        {
            this.GetComponent<AudioSource>().volume = 0.025f;
        }
    }
}
