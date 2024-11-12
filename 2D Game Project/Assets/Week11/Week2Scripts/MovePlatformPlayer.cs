using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformPlayer : MonoBehaviour
{
    //horizontalInput
    private float horizontalInput;
    //movement speed
    public int speed = 5;
    private Rigidbody2D rb2d;
    //force applied for jumping
    public int jumpForce = 10;
    //check if player is facing right or left
    private bool isFacingRight = true;

    //wall interaction
    //flag to check if player is wall sliding
    bool isWallSliding;
    //speed of sliding down wall
    float wallSlidingSpeed = 2f;

    //flag to check if player is wall jumping
    bool isWallJumping;
    //direction for wall jump
    float wallJumpingDirection;
    //time window for wall jump
    float wallJumpingTime = .2f;
    //counter for wall jumping time
    float wallJumpingCounter;
    //duration of wall jump
    float wallJumpingDuration = .4f;
    //force for wall jump
    private Vector2 wallJumpingPower = new Vector2(5f, 10f);

    //collision detection variables
    public float checkRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform wallCheck;
    public LayerMask wallLayer;

    public GameObject respawnPos;

    //shooting variables
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

        //when w is pressed and player is grouded they can jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        //if player releases the w key while moving upwards, reduces jump height
        if(Input.GetKeyUp(KeyCode.W) && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
       
        WallSlide();
        WallJump();
        Respawn();

        //flip character based on movement direction but not if they are wall jumping
        if(!isWallJumping)
        {
            Flip();
        }

        //handles shooting when player hits e 
        shootTimer += Time.deltaTime;
        if(Input.GetKey(KeyCode.E) && shootTimer >= shootInterval)
        {
            Shoot();
            Debug.Log("called shoot");
            //reset timer
            shootTimer = 0f;
        }
    }

    //used for specific physics related updates
    //consistent time intervals indepdent of frame rate. 
    private void FixedUpdate()
    {
        //if not wall jumping, apply horizontal movement 
        if (!isWallJumping)
        {
            rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);
        }
    }

    //flip the players direction sprite to face the direction of movement
    private void Flip()
    {
        if(isFacingRight && horizontalInput < 0 || !isFacingRight && horizontalInput > 0f)
        {
            //toggle facing direction, this just does the opposite of whatever it is, flips it
            isFacingRight = !isFacingRight;
            //we use local scale because its more efficient than roating an object
            //get current local scale store in var
            Vector3 localScale = transform.localScale;
            //flip the sprite on the x-axis
            localScale.x *= -1f;
            transform.localScale = localScale; //set flipped scale back to the objects localscale
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

    //in order to wall jump we have to wall slide first because we are able to jump with force off the walls when we slide
    private void WallSlide()
    {
        //not on the ground, on the wall, and horizontal input is -1 or 1
        if ((isWalled() && !isGrounded() && horizontalInput != 0f))
        {
            isWallSliding = true;
            //Debug.Log("player is wall sliding");
            //slide down the wall with limited speed\
            //controlling vertical movement
            //adjusts players velocity based on condition (wall sliding)
            //mathf.clamp restricts vertical speed within a range, it has 3 parameters
            //1st: speed at which player is moving up or down
            //minimum value for vertical velocity when player is wall slider ensures player doesnt fall down too quickly
            //third parametere: max value for vertical velocity (largest possible float number) there is no limit on upward velocity
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            //player is not wall sliding
            isWallSliding = false;
        }
    }

    //jumping off of walls
    private void WallJump()
    {
        //turn off walljumping so we can do a new one
        //if player is wall sliding prepare for wall jump
        if(isWallSliding)
        {
            //Debug.Log("player is wall sliding and preparing wall jump");
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x; //jump in the opposite direction
            //wall jumping counter: how much time is left before the player can walljump again  
            wallJumpingCounter = wallJumpingTime; //reset timer for jumping window

            CancelInvoke(nameof(StopWallJumping)); //cancel any pending wall jump stops
        }
        else
        {
            //decrease wall jump over time
            wallJumpingCounter -= Time.deltaTime; //decrease timer
        }
        // If the player presses W within the wall jump window
        if (Input.GetKey(KeyCode.W) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            //apply wall jump force
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
        //if player is below certain number and is not grounded respawn
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
            //shorthand for writing if statement (if(isfacingright) bulletdirection =1 else bulletdiretion = -1
            float bulletDirection = isFacingRight ? 1f : -1f;
            PlayerProjectile bulletScript = bullet.GetComponent<PlayerProjectile>();

            if(bulletScript != null )
            {
                //set direction for the bullet
                bulletScript.SetDirection(bulletDirection);
            }
        }
        else
        {
            Debug.Log("Bullet Prefab not assigned");
        }
    }


    //give player an extra life 
    //last thing we do
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {

            Health playerHealth = GetComponent<Health>();
            //add extra life
            playerHealth.lives++;
            //update lives text
            playerHealth.UpdateLivesText();
            Destroy(collision.gameObject);
        }
    }

    /*Jumping:
    When the player presses the W key and is standing on the ground, they will jump upwards. If the player is already going up, releasing the W key will make the jump shorter (by reducing the upward speed).

    Wall Sliding and Wall Jumping:
    If the player is against a wall and not on the ground, the player will slide down the wall slowly.
    If the player is sliding on the wall and presses W, they can perform a wall jump, pushing away from the wall to jump in the opposite direction.*/
}
