using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //var for movement on x
    //var for movement on y
    public float speed = 1f;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

       rb2D.velocity = new Vector2 (horizontalInput * speed, 
           verticalInput * speed);
    }
}
