using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Movimentação
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 7f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    private Animator animator;
    private bool doubleJump;
    //Movimentação

    //GameOver
    public GameObject Enemy;

    Vector2 startPos;
    //GameOver

    //Movimentação
    private void Start()
    {
        animator = GetComponent<Animator>();
        Hearts.lifes = 3;
        startPos = transform.position;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    } 

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal == 0 )
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }


        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
            if (isGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doubleJump = !doubleJump;
            }
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    //Movimentação

    //GameOver
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pill")
        {
            Destroy(Enemy);
            Destroy(collision.gameObject);
        }

        if (collision.collider.tag == "Limbo")
        {
            if (Hearts.lifes == 1)
            {
                GameOver();
            }
            else
            {
                Hearts.lifes--;
                transform.position = startPos;
            }
        }

        void GameOver()
        {
            print("Fim de Jogo");
            SceneManager.LoadSceneAsync(1);
        }

        if (collision.collider.tag == "Enemy")
        {
            if (Hearts.lifes == 1)
            {
                GameOver();
            }
            else
            {
                Hearts.lifes--;
                transform.position = startPos;
            }
        }
    }
    //GameOver
}
