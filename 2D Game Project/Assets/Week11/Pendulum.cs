using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //how fast the pendulum swings
    public float moveSpeed = 25;
    //left limit angle
    public float leftAngle; //-.35
    //right limit angle
    public float rightAngle; //.35

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rb2d.angularVelocity = moveSpeed;
        Move();
    }

    //checks current rotation of pendulum and determines whether to change swinging direction
    public void ChangeDirection()
    {
        //if it is greater than rightangle on z axis, it switches direction by changing bool to false
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        //if it goes below leftangle switches direction to clockwise by setting bool to true
        if(transform .rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    //handles actually swinging of pendulum
    public void Move()
    {
        //calls it to determine if direction of movement needs to be changed
        ChangeDirection();
        //if it is true it sets angularVelocity of rigidbody to move speed causing to swing in that direction
        if(movingClockwise)
        {
            rb2d.angularVelocity = moveSpeed;
        }
        //if it is not true it sets angular velocity to the negative of the moveSpeed causing counterclockwise
        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1 * moveSpeed;
        }
    }
}
