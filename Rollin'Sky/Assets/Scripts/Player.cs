using UnityEngine;

public class Player : MonoBehaviour
{
    public const float MAX_SPEED = 10.0f;
    public const float NORMAL_SPEED = 5.0f;
    public const float MIN_SPEED = 1.0f;

    private Rigidbody rb;
    private Transform tr;

    private Vector3 speed;
    private Vector3 accelertion;

   

    // Start is called before the first frame update
    public void Start()
    {

        //Agafo els components que te el player
        tr = this.transform;
        rb = this.GetComponent<Rigidbody>();

        //Inicialitzo aquests components
        tr.SetPositionAndRotation(new Vector3(0, 2, 1), tr.rotation);
        rb.useGravity = true;

        //Acceleracio hardcoded
        accelertion = new Vector3(0.0f, 0.0f, 0.25f);

        //Velocitat inicial
        speed = new Vector3(0.0f, 0.0f, MIN_SPEED);

    }

    // Update is called once per frame
    public void Update()
    {
        //Calcul de velocitat puntual en l'eix z (v + v*a);
        speed = speed + new Vector3(speed.x * accelertion.x * Time.deltaTime,
            speed.y * accelertion.y * Time.deltaTime, speed.z * accelertion.z * Time.deltaTime);
       
        //Ajustament de velocitat en eix z
        if (speed.z > NORMAL_SPEED) speed.z = MAX_SPEED;

        //Calcul de vel en eix x
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += new Vector3(0.05f, 0.0f, 0.0f);
            Debug.Log("Right Arrow pressed!");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += new Vector3(-0.05f, 0.0f, 0.0f);
            Debug.Log("Left Arrow pressed!");
        }

        rb.AddForce(speed);
    }

    //My methods

    public Vector3 getPosition()
    {
        return tr.position;
    }
}
