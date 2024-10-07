using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForObjects : MonoBehaviour
{
    public float obstacleSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if it is greater than -5
        if(transform.position.y > -5)
        {
            //vector2.down shorthand for (0, -1)
            //time.delta time smoothly moves with frame rate
            //how fast we want the obstacle speed to move
            //transform.translate calculates all of this and moves the object 
            transform.Translate(Vector2.down * Time.deltaTime * obstacleSpeed);
            
        }
        //less than or equal to -5
        else
        {
            Destroy(gameObject);
        }
    }
}
