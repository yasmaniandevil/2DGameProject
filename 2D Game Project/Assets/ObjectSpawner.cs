using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab;
    public GameObject particles;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //creates a new position, stores the x, y, z
            //random.range anything from -6 to 6 on the x axis
            //anything -3, 3 on the y axis
            //becausr it only takes two values here x and y, z is always 0
            //Vector3 randomPosition = new Vector3(Random.Range(-6, 6), Random.Range(-3, 3));
            //Vector3 randomScale = new Vector3(Random.Range(.5f, 2), Random.Range(2, .5f), 1);
            //spawn obj function takes position and scale
            //we are passing in position and scale
            //calling the function here
            //SpawnObject(randomPosition, randomScale);
            GameObject newObj = Instantiate(particles, new Vector3(-1, 0, 0), Quaternion.identity);
            SpawnObject(new Vector3(0,0,0), new Vector3(1,1,1));
            Destroy(newObj, 2f);
        }
       
    }

    //function is a block of code that performs a specific task or action when called
    //helps organize and manage code by breaking it into reusabled manageable pieces
    //spawnobject takes two parameters
    //takes the position
    //takes the scale
    //parameters are var that are declared in a function definition and used to pass
    //info/data into the function when its called.
    //they act as placeholders for the values they are also called arguments
    private void SpawnObject(Vector3 position, Vector3 scale)
    {
        //instantiates the object at a specific position
        //quaterninon identity for obj rotation, this means there is no rotation
        GameObject newObj = Instantiate(objectPrefab, position, Quaternion.identity);
        //we have to set the scale because Instantiate does not have scale, but it has position
        //when you want to instatiate it will use the original scale of the prefab
        //if we want to change the oject scale after it instatiates we have to set it
        newObj.transform.localScale = scale;
    }

 
}
