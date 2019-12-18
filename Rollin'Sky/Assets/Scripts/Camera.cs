
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform tr;
    private GameObject pc;
    private GameObject bg;

    private Camera cam;

    private float iniFOV;
    private float maxFOV;
    private float minFOV;
    private float stepFOV;


    // Start is called before the first frame update
    public void Start()
    {
        cam = this.GetComponent<Camera>();
        tr = GetComponent<Transform>();
        //Initialize vars
        tr.Rotate(new Vector3(20.0f, 0.0f, 0.0f));

        pc = GameObject.Find("Ball");
        //get components

        bg = GameObject.Find("Background");

        tr.SetPositionAndRotation(this.watchPlayer(pc.transform.position),tr.rotation);
        Screen.SetResolution(510, 680, false);

        //FOV STUFF
        UnityEngine.Camera.main.fieldOfView = 30.0f;
        iniFOV = UnityEngine.Camera.main.fieldOfView;
        maxFOV = 35f;
        minFOV = 26.5f;
        stepFOV = 0.1f;

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
        if (pc.GetComponent<PlayerMove>().accelerated)
        {
            if (UnityEngine.Camera.main.fieldOfView < maxFOV)
            {
                UnityEngine.Camera.main.fieldOfView += stepFOV;
            }
        }
        else if (pc.GetComponent<PlayerMove>().slowed)
        {
            if (UnityEngine.Camera.main.fieldOfView > minFOV)
            {
                UnityEngine.Camera.main.fieldOfView -= stepFOV;
            }
        }
        else
        {
            if (UnityEngine.Camera.main.fieldOfView < iniFOV) UnityEngine.Camera.main.fieldOfView += stepFOV;
            else if (UnityEngine.Camera.main.fieldOfView > iniFOV) UnityEngine.Camera.main.fieldOfView -= stepFOV;
        }
        return new Vector3(playerPos.x, 0.0f, playerPos.z) + new Vector3(0.0f, 4.0f, -4.5f);
    }

}
