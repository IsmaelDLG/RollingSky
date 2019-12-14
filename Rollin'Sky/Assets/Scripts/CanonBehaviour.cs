using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    public Vector3 position;
    public Vector3 shootPosition;
    private float reload = 0.0f;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        reload = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
        shootPosition = new Vector3 (position.x, position.y, position.z);
        if (reload >= 3.0f)
        {
            Debug.Log("shooting");
            GameObject obj = (GameObject)Instantiate(bullet, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
            reload = 0.0f;
        }
        reload += Time.deltaTime;
    }
}
