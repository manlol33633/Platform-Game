using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded;
    private int jumpCount = 0;
    private Rigidbody2D rb;
    private float horizontalMovement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontalMovement * speed, 0);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >= 2 && !isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            isGrounded = false;
        } else if (isGrounded) {
            jumpCount = 0;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}
