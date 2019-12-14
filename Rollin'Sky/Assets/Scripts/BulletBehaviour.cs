using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(!(Time.timeScale == 0))
        {
            this.transform.Translate(new Vector3(0.025f, 0.0f, 0.0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().killPlayer();

        }
    }
}
