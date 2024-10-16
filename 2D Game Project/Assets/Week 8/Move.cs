using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 5f;

    //list starts empty and grows as player collects keys
    //List<Key> keysCollected = new List<Key>();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2 (horizontalInput * speed, verticalInput * speed);
    }

    //passing an instance of the Key class as an argument when calling CollectKey
    //var refers to specific instance of that key (the one the player collides with)
    /*public void CollectKey(Key key) 
    {
        keysCollected.Add(key); //add the collected key to the list
        Destroy(key.gameObject); //remove key from scene
        
    
    }*/

    //checks when player has correct key
    /*public void TryUnlock(Lock lockObject) 
    { 
        foreach(Key key in keysCollected) //loops thru key collected list
        {
            if(key.keyID == lockObject.lockID) //if the key ID matches the lock ID
            { 
                lockObject.Unlock(); //unlock the lock
                return; //exit the method after unlocking
            
            }
        }

        Debug.Log("You do not have the righr key"); //if no matching key is found
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking if the object the player collided with has the Key component
        Key key = collision.gameObject.GetComponent<Key>(); //checks if player collides with a key
        if(key != null)
        {
            //pass the collided key to CollectKey
            CollectKey(key); //collect key if player collides with it
        }

        Lock lockObject = collision.gameObject.GetComponent<Lock>(); //checks if player collides with a lock
        if(lockObject != null)
        {
            TryUnlock(lockObject);
            Debug.Log("try unlock");
        }
    }*/
}
