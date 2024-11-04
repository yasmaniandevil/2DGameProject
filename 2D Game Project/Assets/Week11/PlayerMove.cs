using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    public float jumpForce = 4f;
    public bool isGrounded;

    private int playerLives = 5;
    public TextMeshProUGUI livesText;

    public Transform respawn;
    private float moveTime = 0.5f;

    public List<GameObject> disappearingPlatforms = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //display lives text on start so it shows up
        UpdateLivesText();

        //find all disappearing platforms in the scene automatically
        if(disappearingPlatforms == null || disappearingPlatforms.Count == 0)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        //only using horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //change velocity on the x but keep it the same on the y so nothing happens
        rb2d.velocity = new Vector3(horizontalInput * speed, rb2d.velocity.y, 0);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            //few different ways to do jump, with add force or velocity
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            //rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
        }

        Respawn();

        //restarts the scene
        if (Input.GetKey(KeyCode.R))
        {
            //SceneManager.LoadScene(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player is on the platform
        if (collision.gameObject.CompareTag("Ground"))
        {
            //set it to true
            //isGrounded = true;

            Debug.Log("colliding points: " + collision.contacts.Length);
            Debug.Log("Normal: " + collision.contacts[0].normal);

            Vector2 normal = collision.GetContact(0).normal;
            if (normal == Vector2.up)
            {
                isGrounded = true;
            }

            foreach(var item in collision.contacts)
            {
                Debug.DrawLine(item.point, item.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
            }
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if player exits the ground collision platform
        if (collision.gameObject.CompareTag("Ground"))
        {
            //sets grounded to false
            isGrounded = false;
        }
    }

    //function that keeps lives text updated!
    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + playerLives.ToString();
    }

    private void Respawn()
    {
        //checks the position of the player and if the player is not grounded
        if(transform.position.y < 0  && isGrounded == false)
        {
            //move timer countdown
            moveTime -= Time.deltaTime;
            //if move time equals zero
            if(moveTime < 0)
            {
                //respawn the player
                transform.position = respawn.position;
                //decreases a life
                playerLives--;
                //update the lives text
                UpdateLivesText();

                foreach(GameObject platform in disappearingPlatforms)
                {
                    platform.GetComponent<dissapearingPlatform>().ResetPlatform();
                }

                //reset move time for next fall
                moveTime = 0;
            }
            
            
        }
    }


}
