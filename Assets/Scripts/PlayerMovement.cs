using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public float maxSpeed;

    public GameObject NeogulMan;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxisRaw("Horizontal");

        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < maxSpeed * (-1)) 
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);




        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        } 
    }
}
