using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItRainsStuff : MonoBehaviour
{
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameObject.Find("Ball").transform.position + new Vector3(0f, 10f, 10f);
    }
}
