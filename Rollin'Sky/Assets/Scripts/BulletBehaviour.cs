using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0.025f, 0.0f, 0.0f));
    }
}
