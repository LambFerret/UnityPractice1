using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public GameObject NeogulMan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        float h = Input.GetAxis("Horizontal");
        if (h > 0)
        {
            transform.rotation = new Quaternion(0, 1, 0, 0);
            transform.position -= new Vector3(-velocity, 0, 0);
        }
        else if (h < 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
            transform.position -= new Vector3(velocity, 0, 0);
        }
        transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);
    }
}
