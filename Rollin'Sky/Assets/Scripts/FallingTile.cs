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
            if (Time.timeScale != 0){
                if (GameObject.Find("Ball").GetComponent<PlayerMove>().accelerated)
                {
                    this.transform.Translate(new Vector3(0.0f, -0.009f, 0.0f));
                }
                else if (GameObject.Find("Ball").GetComponent<PlayerMove>().slowed)
                {
                    this.transform.Translate(new Vector3(0.0f, -0.025f, 0.0f));
                }
                else
                {
                    this.transform.Translate(new Vector3(0.0f, -0.006f, 0.0f));
                }
            }
        }
    }
}
