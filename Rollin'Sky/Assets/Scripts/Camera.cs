
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform tr;
    public GameObject pc;

    // Start is called before the first frame update
    public void Start()
    {
        tr = GetComponent<Transform>();
        //Initialize vars
        tr.Rotate(new Vector3(30.0f, 0.0f, 0.0f));

        //get components
        tr.SetPositionAndRotation(this.watchPlayer(pc.transform.position),tr.rotation);  
    }

    // Update is called once per frame
    public void Update()
    {
        tr.SetPositionAndRotation(this.watchPlayer(pc.transform.position), tr.rotation);
    }

    //My methods
    public Vector3 watchPlayer(Vector3 playerPos)
    {
        return playerPos + new Vector3(0.0f, 4.0f, -4.5f);
    }

}
