using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTIle : MonoBehaviour
{
    public static bool stageClear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stageClear = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        stageClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
