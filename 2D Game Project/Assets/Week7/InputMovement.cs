using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 5;
    private float score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int collisionCount = 0;

    private bool hasPowerUp = false;
    private float powerUpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameOverText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.Floor(score).ToString();

        if(hasPowerUp)
        {
            powerUpTime -= Time.deltaTime;
            if(powerUpTime <= 0)
            {
                hasPowerUp = false;
                speed /= 2;
            }
        }

        Debug.Log("speed: " + speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacles"))
        {
            collisionCount++;
            //Debug.Log("collisionCount: " + collisionCount);
            if(collisionCount > 3)
            {
                gameOverText.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }

    public void ActivatePowerUp(float duration)
    {
        //check if player already has a power up
        //if player does not have a power up
        if(!hasPowerUp)
        {
            //set to true give player power up
            hasPowerUp = true;
            powerUpTime = duration;
            speed *= 2;
        }
    
    }
}
