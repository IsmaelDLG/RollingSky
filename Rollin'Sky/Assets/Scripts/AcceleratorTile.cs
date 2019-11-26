using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorTile : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().accelerate();
        }
    }
}
