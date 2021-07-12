using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject NeogulMan;
    public float jump;
    public float speed;
    bool isJumping = false;
    Rigidbody2D rb;
    Animator ani;
    Vector3 playerDir;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isJumping = true;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
    void FixedUpdate()
    {
        Move();
        Jump();

    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            playerDir = Vector3.right;
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            playerDir = Vector3.left;

        }
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rb.velocity.x > speed)
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else if (rb.velocity.x < speed * (-1))
            rb.velocity = new Vector2(speed * (-1), rb.velocity.y);

    }

    void Jump()
    {
        if (!isJumping)
            return;
        if (playerDir == Vector3.left)
        {
            Vector2 jumpVelocity = new Vector2(-jump, jump * 2);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        }
        else
        {
            Vector2 jumpVelocity = new Vector2(jump, jump * 2);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        }
        isJumping = false;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("attach" + other.gameObject.layer);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("detach" + other.gameObject.layer);
    }
}
