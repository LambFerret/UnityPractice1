using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject neogulMan;
    public float jump;  // 절대 점프값
    public float jumpX; // X축 점프값 보정
    public float jumpY; // Y축 점프값 보정
    public float speed; // 이동속도
    public int Life;    // 목숨
    public int score;   // 점수
    public int scoreper;// 한개당 점수


    bool isJumping = false; //점프 감지
    bool isAir = false;     //공중 감지
    int scoreCount;         //스코어 아이템 갯수 <- 다시 알아보는게 좋을듯
    Vector3 playerDir;      //보는 방향

    // 구조체 초기화
    Rigidbody2D rb;     
    Animator ani;       


    void Start()
    {
        // 초기화
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        scoreCount = 8;
        score = 0;
        Life = 3;
    }


    void Update()
    {
        // X키로 점프
        if (Input.GetKeyDown(KeyCode.X))
        {
            isJumping = true;
        }

        // 공중이면 키조작이 먹지 않음
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



    // 움직임
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
            Vector2 jumpVelocity = new Vector2(-jump * jumpX, jump * jumpY);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 jumpVelocity = new Vector2(jump * jumpX, jump * jumpY);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        isJumping = false;

    }
    

    // 수정 중
    void Ladder()
    {
        bool h = Input.GetKey(KeyCode.UpArrow);
        if (h)
        {
            neogulMan.layer = 4;
            rb.gravityScale = 0;
            transform.position += new Vector3(0, speed, 0);
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
    }
    void LadderOut()
    {
        this.rb.gravityScale = 1;
        this.gameObject.layer = 0;

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            isAir = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            score += scoreper;
            scoreCount -= 1;
        }

        if (other.gameObject.layer == 7)
        {
            Ladder();
        }

        if ((other.gameObject.layer == 8) || (other.gameObject.tag == "monster"))
        {
            Life--;   
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            isAir = true;
        }

        if (other.gameObject.layer == 7)
        {
            LadderOut();
        }
    }
}
