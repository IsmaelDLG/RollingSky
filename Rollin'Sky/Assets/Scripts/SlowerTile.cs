﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().slow();
            Debug.Log("Collider activated");
        }
    }
}
