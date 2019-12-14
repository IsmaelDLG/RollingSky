using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GeiserBehaviour : MonoBehaviour
{
    public bool erupting;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        erupting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime >= 3.0f)
        {
            erupting = true;
        }
        spawnTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (erupting)
            {
                other.gameObject.GetComponent<PlayerMove>().killPlayer();
            }
        }
    }
}
