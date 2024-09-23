using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TwoBullet : MonoBehaviour
{
    //refrence to rigidbody comp
    private Rigidbody2D rb2D;
    //speed at which the bullet moves
    public float moveSpeed = 10;
    //refrence to TMP Text
    public TextMeshProUGUI scoreText;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody attached to the gameobj
        rb2D = GetComponent<Rigidbody2D>();
        //call the movebullet function to set inital velocity of the bullet
        MoveBullet(Vector3.right, moveSpeed);

        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // In this case, we don't need to continuously move the bullet
        // because the Rigidbody2D physics engine will handle its movement
        // after the initial velocity is applied in Start().
        // So we don't need to call MoveBullet here again.

        /* Once a velocity is set on a Rigidbody2D, the object moves in that direction at the specified speed every frame.
        The physics engine calculates the position change automatically based on the velocity. 
        There’s no need to manually adjust the position of the object 
        every frame (as you would do with transform.position in non-physics-based movement).*/
    }

    private void MoveBullet(Vector3 direction, float speed)
    {
        //transform.position += direction * speed * Time.deltaTime;
        rb2D.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        AddPoints(1);
        
    }

    public void AddPoints(int points)
    {
        playerScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString();
    }
}
