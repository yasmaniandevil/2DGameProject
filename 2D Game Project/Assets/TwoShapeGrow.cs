using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoShapeGrow : MonoBehaviour
{
    //transform component of the square
    //create a variable of type Transform stores it in transformSquare
    private Transform transformSquare;
    public float moveSpeed;
    public float growSpeed;
    //growth rate along x and y axis
    public int x;
    public int y;

    private float minX = -6.0f;
    private float maxX = 6.0f;

    //direction of movement: 1 means to the right, -1 means to the left
    private int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        //initalize transformSquare by getting the transform comp of gameobject
        transformSquare = GetComponent<Transform>();
        Debug.Log("original size: " + transformSquare.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        //added with direction it knows to move right
        transformSquare.position += new Vector3(moveSpeed * direction * Time.deltaTime, 0, 0);

        //rotate it
        transformSquare.Rotate(Vector3.up * 45 * Time.deltaTime);

        //move along y axis
        //transformSquare.position += new Vector3(0, moveSpeed * direction * Time.deltaTime, 0);

        //if the square position on the x axis is greater than maxX or less than minX reverse the direction
        if (transformSquare.position.x > maxX || transformSquare.position.x < minX)
        {
            direction *= -1;
        }

        //transform local scale will only happen if local scale.y is less than 6
        if(transformSquare.localScale.y < 6)
        {
            transform.localScale += new Vector3(x, y, 0) * growSpeed * Time.deltaTime;
        }
    }
}
