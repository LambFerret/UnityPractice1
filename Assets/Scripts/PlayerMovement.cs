using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject NeogulMan;
    public float jump;
    public float jumpX;
    public float jumpY;

    public float speed;
    public int score;
    public int scoreper;
    bool isJumping = false;
    bool isAir = false;
    int scoreCount;

    Rigidbody2D rb;
    Animator ani;
    Vector3 playerDir;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        scoreCount = 6;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isJumping = true;
        }
        if (!isAir)
        {
            if (Input.GetButtonUp("Horizontal"))
            {
                ani.SetBool("isMoving", true);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            Move();
            Jump();
        }
       

    }
    void FixedUpdate()
    {
        
        

    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        ani.SetBool("isMoving", false);
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

            Vector2 jumpVelocity = new Vector2(-jump* jumpX, jump * jumpY);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        }
        else
        {
            Vector2 jumpVelocity = new Vector2(jump * jumpX, jump * jumpY);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        }
        isJumping = false;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            isAir = false;
            Debug.Log("attach" + other.gameObject.layer);
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            score += scoreper;
            scoreCount -= 1;
            Debug.Log(scoreCount);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            isAir = true;
            Debug.Log("detach" + other.gameObject.layer);
            
        }
    }
}
