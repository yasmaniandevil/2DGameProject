using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformPlayer : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D rb2d;
    public int jumpForce;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
        }
    }
}
