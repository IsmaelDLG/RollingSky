using System;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public const float MAX_SPEED = 0.75f;
    public const float NORMAL_SPEED = MAX_SPEED/2.0f;
    public const float MIN_SPEED = MAX_SPEED/MAX_SPEED;

    private Rigidbody rb;
    private Transform tr;

    private Vector3 speed;
   
    // Start is called before the first frame update
    public void Start()
    {

        //Agafo els components que te el player
        tr = this.transform;
        rb = this.GetComponent<Rigidbody>();

        //Inicialitzo aquests components
        tr.SetPositionAndRotation(new Vector3(0, 2, 1), tr.rotation);
        rb.useGravity = true;
        rb.mass = 0.1f;

        //Velocitat inicial
        speed = new Vector3(0.0f, 0.0f, MIN_SPEED);

    }

    // Update is called once per frame
    public void Update()
    {
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
        rb.AddForce(speed);
    }

    //vf = vo + a*t
    private void accelerateZ()
    {
        //Calcul de velocitat puntual en l'eix z (v + v*a);
        speed.z += 3.0f * Time.deltaTime;

        //Ajustament de velocitat en eix z
        if (speed.z > NORMAL_SPEED) speed.z = MAX_SPEED;
    }

    private void accelerateX(float dir)
    {
        if (dir != (speed.x / abs(speed.x))) speed.x = 0.0f;
        speed.x += 500.0f * Time.deltaTime*dir;
        if (speed.x > MAX_SPEED*5) speed.x = MAX_SPEED*5;
        else if (speed.x < MAX_SPEED * (-5)) speed.x = MAX_SPEED * (-5);
    }

    private float abs(float x)
    {
        if (x < 0) return (x * -1.0f);
        return x;
    }

    //My methods
}
