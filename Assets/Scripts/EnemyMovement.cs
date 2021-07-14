using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    Rigidbody2D rb;

    float distance;
    RaycastHit2D rayhit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
  
}
