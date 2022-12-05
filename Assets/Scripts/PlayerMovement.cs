using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float count;
    
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
            anim.SetBool("Jump", true);
            Debug.Log("Jump");
            count++;
        } else {
            anim.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3) {
            rb2d.velocity = new Vector2(0, jumpForce);
            
            isGrounded = false;
            jumpCount++;
        } else if (isGrounded) {
            jumpCount = 0;
        }

        if (Input.GetKey(KeyCode.S)) {
            rb2d.gravityScale = 5;
        } else {
            rb2d.gravityScale = 2;
        }

        if (transform.position.y <= -10) {
            Destroy(gameObject);
            SceneManager.LoadScene("DeathScreen");
        }

        if (rb2d.velocity.y < -2f) {
            anim.SetBool("Falling", true);
        } else {
            anim.SetBool("Falling", false);
        }

        if (horizontalMovement > 0) {
            anim.SetBool("Right", true);
        } else if (horizontalMovement < 0) {
            anim.SetBool("Left", true);
        } else {
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }
        Debug.Log(horizontalMovement);
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
