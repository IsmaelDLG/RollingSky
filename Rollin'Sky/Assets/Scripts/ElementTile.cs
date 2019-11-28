using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().changeElement("grass");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
