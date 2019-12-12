﻿using System;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    public const float MAX_SPEED = 1.0f*2.0f;
    public const float NORMAL_SPEED = MAX_SPEED/2.0f;
    public const float MIN_SPEED = NORMAL_SPEED/2.0f;
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
    //Inicialitzo aquests components
    //tr.Rotate(new Vector3(0, 90, 0));
        tr.SetPositionAndRotation(new Vector3(0, 1.4f, 1),new Quaternion(0,0,0,0)) ;

        //Velocitat inicial
        speed = new Vector3(0.0f, 0.0f, NORMAL_SPEED);

    }

    // Update is called once per frame
    public void Update()
    {
        stillAlive();
        //Acceleració constant fins arribar al limit
        accelerateZ();
        
        //Calcul de vel en eix x
        if (Input.GetKey(KeyCode.RightArrow))
            this.accelerateX(1.0f);
        else if (Input.GetKey(KeyCode.LeftArrow)) 
            this.accelerateX(-1.0f);
        else //Volem seguir rectes
        {
            //Contrarrestem la força actual
            if (rb.velocity.x != 0)
            {
                speed.x = rb.velocity.x * (-1.0f);
            }
        }
        //Afegim la força al player.
        if (Time.timeScale != 0)
        {
            rb.AddForce(speed);
        }

    }

    public void killPlayer()
    {
        isDead = true;
    }

    public void accelerate()
    {
        accelerated = true;
        speed.z = MAX_SPEED;
        Debug.Log("accelerating player");
    }

    public void slow()
    {
        slowed = true;
        speed.z = MIN_SPEED;
    }

    public void changeElement(string elem)
    {
        element = elem;
        Debug.Log(element);
    }

    public void stillAlive()
    {
        if (tr.position.y <= -4)
        {
            isDead = true;
        }
    }

    //vf = vo + a*t
    private void accelerateZ()
    {
        if (accelerated)
        {
            if (speed.z > NORMAL_SPEED) speed.z -= 0.75f * Time.deltaTime;
            if (speed.z <= NORMAL_SPEED) accelerated = false;

        }
        else if (slowed)
        {
            Debug.Log(speed.z);
            if (speed.z < NORMAL_SPEED) speed.z += 0.5f * Time.deltaTime;
            if (speed.z >= NORMAL_SPEED) slowed = false;
            Debug.Log(speed.z);
        }
        else
        {
            //Calcul de velocitat puntual en l'eix z (v + v*a);
            speed.z += 3.0f * Time.deltaTime;

            //Ajustament de velocitat en eix z
            if (speed.z > NORMAL_SPEED) speed.z = NORMAL_SPEED;
        }
    }

    private void accelerateX(float dir)
    {
        if (dir != (speed.x / abs(speed.x))) speed.x = 0.0f;
        speed.x += 500.0f * Time.deltaTime*dir;
        if (speed.x > MAX_SPEED*5) speed.x = NORMAL_SPEED*5;
        else if (speed.x < MAX_SPEED * (-5)) speed.x = NORMAL_SPEED * (-5);
    }

    private float abs(float x)
    {
        if (x < 0) return (x * -1.0f);
        return x;
    }

    //My methods
}
