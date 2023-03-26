using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float healthPlayer = 100;



    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private float jump = 8;

    private float horizontalMove;
    private bool facingRight = true;

    private bool isGrounded = true;
    [SerializeField]
    private int jumpCount;

    [SerializeField]
    private int jumpValue = 3 ;

    void Update()
    {
        playerHP0();


        Move();
        SetFlip();
        if (Input.GetKeyDown(KeyCode.Space)&& jumpCount > 0)
        {
            Jump();
        }

        if (isGrounded)
        {
            jumpCount = jumpValue;
        }
    }

    private void FixedUpdate()
    {
        SetMove();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            isGrounded = true;
        }
    }

    public void DecPlayerHP(float amount)
    {
        healthPlayer -= amount;
    }

    public void playerHP0()
    {
        if(healthPlayer <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }

    public void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }
    public void SetMove()
    {
        rb2d.velocity = new Vector2(horizontalMove * speed, rb2d.velocity.y);
    }


    public void SetFlip()
    {
        if(horizontalMove < 0 && facingRight)
        {
            Flip();
        }
        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);
    }

    private void Jump()
    {
        rb2d.velocity = Vector2.up * jump;
        isGrounded = false;
        jumpCount--;
    }

}
