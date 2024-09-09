using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3Movement : MonoBehaviour
{
    public float forceAmount;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("pressed W");
            rb2d.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down * forceAmount);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * forceAmount);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * forceAmount);
        }

        rb2d.velocity *= 0.999f;

    }
}
