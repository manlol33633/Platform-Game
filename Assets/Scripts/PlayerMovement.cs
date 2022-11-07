using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    private Rigidbody2D rb2d;
    private int jumpCount;
    private float horizontalMovement;
    
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    void Update() {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3) {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            jumpCount++;
        } else if (isGrounded) {
            jumpCount = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
