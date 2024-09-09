using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //float for speed
    public float speed = 1f;
    //define rigidbody var to refrence the rigidbody comp
    private Rigidbody2D rb2D;
    //float will store the vertical velocity when jumping
    public float jumpForce = 5f;

    private Transform transformSquare;
    //public GameObject particleEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        //initialized the 4b2d with the rigidbody comp attached to script
       rb2D = GetComponent<Rigidbody2D>();

       transformSquare = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input for horiziontal movement using Unity's built in input system(A/D or left and right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        //get input for vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        //apply the velocity to the ridigbody2D based input
        //.velocity is a property of rb component 
        //represents speed and direction of the object
        //velocity is a vector, it has direction and magnitude(how fast its moving in that direction)
        // = (assignment operator) assigning a new value to rb.velocity, calculated on players input and movement speed
        //vector2 we are passing in the x and y
        rb2D.velocity = new Vector2 (horizontalInput * speed, 
           verticalInput * speed);

        //jumping
        //check if space is pressed
        if(Input.GetKey(KeyCode.Space))
        {
            //apply upward force to the rigidbody for the jump
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            
        }
    }

    //built in unity event method triggered during 2D collisions
    //private just for this script
    //void means it does not return a value
    //collision 2 objects with colliders and one with a rigidbody
    //() the parameter passed into the method
    //Collision 2D is the data type of the parameter (how int represents an integer)
    //Collision2D represents the data from a 2D collision in unity
    //when unity detecs collision it creates a collision2d Obj that holds the info
    //collision is the name of the variable that will store the Collision2D object when the method is triggered
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
        Debug.Log(collision.gameObject.name);

        //transformSquare.position = new Vector3(0,0,0);
        //Destroy(collision.gameObject);

        //particleEffect.SetActive(true);
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HitTrigger");

    }
}
