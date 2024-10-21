using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ship : MonoBehaviour
{
    public float forceAmount = 2f;
    private Rigidbody2D rb2d;

    public float boundary;
    public float health; 

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector3.left * forceAmount);
            
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector3.right * forceAmount);

        }

        float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //GameOverText
            Debug.Log("Health: " + health);

        }
    }
}
