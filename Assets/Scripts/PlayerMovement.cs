using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator anim;
    private int wallJumpCount;
    private bool isGrounded;
    private bool isWallSliding;
    private Rigidbody2D rb2d;
    private int jumpCount;
    private float horizontalMovement;
    
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        wallJumpCount = 0;
        anim = GetComponent<Animator>();
    }

    void Update() {
        horizontalMovement = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3) {
            anim.SetBool("Space", true);
        } else {
            anim.SetBool("Space", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3) {
            rb2d.velocity = new Vector2(0, jumpForce);
            
            isGrounded = false;
            jumpCount++;
        } else if (isGrounded) {
            jumpCount = 0;
        }
    }

    void FixedUpdate() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform") {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform") {
            isGrounded = false;
        }
    }
}
