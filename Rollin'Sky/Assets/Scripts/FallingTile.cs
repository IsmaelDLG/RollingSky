using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{

    public bool startFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startFalling = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (startFalling)
        {
            this.transform.Translate(new Vector3(0.0f, -0.05f, 0.0f));
        }
    }
}
