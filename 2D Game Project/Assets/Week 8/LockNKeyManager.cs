using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNKeyManager : MonoBehaviour
{
    // Start is called before the first frame update


    //list starts empty and grows as player collects keys
    List<Key> keysCollected = new List<Key>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectKey(Key key)
    {
        keysCollected.Add(key); //add the collected key to the list
        Destroy(key.gameObject); //remove key from scene


    }

    public void TryUnlock(Lock lockObject)
    {
        foreach (Key key in keysCollected) //loops thru key collected list
        {
            if (key.keyID == lockObject.lockID) //if the key ID matches the lock ID
            {
                lockObject.Unlock(); //unlock the lock
                return; //exit the method after unlocking

            }
        }

        Debug.Log("You do not have the righr key"); //if no matching key is found
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking if the object the player collided with has the Key component
        //finds key component assigns to var
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
    }
}
