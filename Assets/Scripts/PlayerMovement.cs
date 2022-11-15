using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
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
    }

    void Update() {
        horizontalMovement = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3) {
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            rb2d.velocity = new Vector2(jumpForce, jumpForce);
            isGrounded = false;
            jumpCount++;
        } else if (isGrounded) {
            jumpCount = 0;
        } else if (isWallSliding && Input.GetKeyDown(KeyCode.Space)) {
            rb2d.gravityScale = 1;
            rb2d.velocity = jumpForce * transform.up;
            rb2d.velocity = jumpForce * transform.right;
        } else {
            rb2d.gravityScale = 2;
        }
    }

    void FixedUpdate() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Wall") {
            isWallSliding = true; 
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = false;
        }
        if (other.gameObject.tag == "Wall") {
            isWallSliding = false; 
        }
    }
}
