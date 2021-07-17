using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    RaycastHit2D rayHit;
    Ray2D ray;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ray = new Ray2D();
    }


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }


    void FixedUpdate()
    {
        float distance = 4.42f;
        if (speed > 0)
        {
            ray.direction = new Vector3(1, -1, 0);
            rayHit = Physics2D.Raycast(rb.position, ray.direction, distance, ~3);
        }
        else
        {
            ray.direction = new Vector3(-1, -1, 0);
            rayHit = Physics2D.Raycast(rb.position, ray.direction , distance, ~3);

        }
        if (!rayHit)
        {
            speed = -speed;
        }
    }

}
