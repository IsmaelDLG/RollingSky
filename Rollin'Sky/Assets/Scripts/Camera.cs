
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform tr;
    private GameObject pc;
    private GameObject bg;

    // Start is called before the first frame update
    public void Start()
    {
        tr = GetComponent<Transform>();
        //Initialize vars
        tr.Rotate(new Vector3(20.0f, 0.0f, 0.0f));

        pc = GameObject.Find("Ball");
        //get components

        bg = GameObject.Find("Background");

        tr.SetPositionAndRotation(this.watchPlayer(pc.transform.position),tr.rotation);
        Screen.SetResolution(510, 680, false);
        //bg = (GameObject)Instantiate(bg);
    }

    // Update is called once per frame
    public void Update()
    {
        tr.SetPositionAndRotation(this.watchPlayer(pc.transform.position), tr.rotation);
        bg.transform.SetPositionAndRotation(tr.position+new Vector3(0f,-7.25f,18f),bg.transform.rotation);
    }

    //My methods
    public Vector3 watchPlayer(Vector3 playerPos)
    {
        return new Vector3(playerPos.x, 0.0f, playerPos.z) + new Vector3(0.0f, 4.0f, -4.5f);
    }

}
