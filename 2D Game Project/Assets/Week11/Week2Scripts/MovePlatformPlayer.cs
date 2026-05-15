using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformPlayer : MonoBehaviour
{
    private float horizontalInput;
    public int speed = 5;
    private Rigidbody2D rb2d;
    public int jumpForce = 10;
    private bool isFacingRight = true;

    bool isWallSliding;
    float wallSlidingSpeed = 2f;

    bool isWallJumping;
    float wallJumpingDirection;
    float wallJumpingTime = .2f;
    float wallJumpingCounter;
    float wallJumpingDuration = .4f;
    private Vector2 wallJumpingPower = new Vector2(5f, 10f);

    public float checkRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform wallCheck;
    public LayerMask wallLayer;

    public GameObject respawnPos;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private float shootTimer;
    public float shootInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if(Input.GetKeyUp(KeyCode.W) && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
       
        WallSlide();
        WallJump();
        Respawn();

        if(!isWallJumping)
        {
            Flip();
        }

        shootTimer += Time.deltaTime;
        if(Input.GetKey(KeyCode.E) && shootTimer >= shootInterval)
        {
            Shoot();
            Debug.Log("called shoot");
            shootTimer = 0f;
        }
    }

    //used for specific physics related updates
    //consistent time intervals indepdent of frame rate. 
    private void FixedUpdate()
    {
        if (!isWallJumping)
        {
            rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);
        }
    }

    private void Flip()
    {
        if(isFacingRight && horizontalInput < 0 || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    //checks if player is touching ground retuns true or false
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }
    //check if they are touching the wall
    private bool isWalled()
    {
        //return Physics2D.OverlapCircle(wallCheck.position, .2f, wallLayer);

        bool walled = Physics2D.OverlapCircle(wallCheck.position, .2f, wallLayer);
        //Debug.Log("is walled: " + walled);
        return walled;
    }

    private void WallSlide()
    {
        if ((isWalled() && !isGrounded() && horizontalInput != 0f))
        {
            isWallSliding = true;
            //Debug.Log("player is wall sliding");
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            //Debug.Log("player is wall sliding and preparing wall jump");
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x; //jump in the opposite direction
            wallJumpingCounter = wallJumpingTime; //reset timer for jumping window

            CancelInvoke(nameof(StopWallJumping)); //cancel any pending wall jump stops
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime; //decrease timer
        }

        if(Input.GetKey(KeyCode.W) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb2d.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f; //reset counter

            //flip direction if needed
            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        Invoke(nameof(StopWallJumping), wallJumpingDuration); //stop wall jumping after duration
    }

    //resets wall jumping state after the wall jump duration
    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Respawn()
    {
        if(transform.position.y < 0 && !isGrounded())
        {
            transform.position = respawnPos.transform.position;
            Debug.Log("respawn player");
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            //set direction based on players facing direction
            float bulletDirection = isFacingRight ? 1f : -1f;
            PlayerProjectile bulletScript = bullet.GetComponent<PlayerProjectile>();

            if(bulletScript != null )
            {
                bulletScript.SetDirection(bulletDirection);
            }
        }
        else
        {
            Debug.Log("Bullet Prefab not assigned");
        }
    }





}
