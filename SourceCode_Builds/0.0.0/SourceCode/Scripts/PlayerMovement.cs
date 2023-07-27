using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    public KeyCode jumpKey;

    private Rigidbody2D rb;
    private bool isGrounded;
    public bool canJump = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }

    private void Update() {
        HandleWalking();
        HandleJumping();
    }

    void HandleWalking() {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(speed * inputX, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    void HandleJumping() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded) {
            canJump = true; // Player is on the ground, allow jumping
        }

        if (canJump && Input.GetKeyDown(jumpKey)) // Use jumpKey as the jump button
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            canJump = false; // Prevent jumping until grounded again
        }

        // Ensure canJump is set to false when the player leaves the ground
        if (!isGrounded) {
            canJump = false;
        }
    }

}
