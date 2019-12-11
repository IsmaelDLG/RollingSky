using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_move : MonoBehaviour
{

    public const float MAX_SPEED = 0.75f * 2.0f;
    public const float NORMAL_SPEED = MAX_SPEED / 2.0f;
    public const float MIN_SPEED = NORMAL_SPEED / 2.0f;
    public const float LONG = 2 * 3.14159f * 0.25f;

    public bool accelerated = false;
    public bool slowed = false;
    public bool isDead = false;
    private string element = "none";

    private Rigidbody rb;
    private Transform tr;

    private Vector3 speed;

    // Start is called before the first frame update
    public void Start()
    {
        //tr.SetPositionAndRotation(new Vector3(0, 1.4f, 2), new Quaternion(0,0,0,0));

        //Agafo els components que te el player
        tr = this.transform;
        rb = this.GetComponent<Rigidbody>();
        isDead = false;
        accelerated = false;
        slowed = false;
        isDead = false;
        Time.timeScale = 1f;
        //Inicialitzo aquests components
        //tr.Rotate(new Vector3(0, 90, 0));
        tr.SetPositionAndRotation(new Vector3(0, 1.4f, 1), new Quaternion(0, 0, 0, 0));

        //Velocitat inicial
        speed = new Vector3(0.0f, 0.0f, NORMAL_SPEED);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(new Vector3(1f, 0, 0));
        else if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(new Vector3(-1f, 0, 0));
        else if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(new Vector3(0, 0, 1f));
        else if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(new Vector3(0, 0, -1f));

    }
}
