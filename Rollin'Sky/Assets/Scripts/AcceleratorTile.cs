﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().accelerate();
            Debug.Log("Collider activated");
        }
    }
}
