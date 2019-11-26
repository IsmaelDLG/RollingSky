using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTile : MonoBehaviour
{

    private bool jump = false;
    private bool retracted = false;
    private float jumpSpeed = 10;
    private Vector3 restPosition;
    private Vector3 retractPosition;
    private Vector3 activatedPosition;
    // Start is called before the first frame update
    void Start()
    {
        restPosition = this.transform.position;
        retractPosition = restPosition - new Vector3(0.0f, 0.5f, 0.0f);
        activatedPosition = restPosition + new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activateRetract();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activateJumper();
        }
    }

    private void activateRetract()
    {
        retracted = true;
    }

    private void activateJumper()
    {
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(retracted)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, retractPosition, Time.deltaTime * jumpSpeed);
        }
        if(jump)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, activatedPosition, Time.deltaTime * jumpSpeed);
        }
        else
        {
            if (this.transform.position != restPosition)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, restPosition, Time.deltaTime * jumpSpeed);
            }
        }
    }
}
