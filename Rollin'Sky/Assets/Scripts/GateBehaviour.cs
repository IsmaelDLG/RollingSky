using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerMove>().element != "lava")
            {
                other.gameObject.GetComponent<PlayerMove>().killPlayer();
            }
        }
    }
}
