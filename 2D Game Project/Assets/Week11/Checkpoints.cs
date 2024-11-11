using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    //create a var of the playerMove script that stores it
    private PlayerMove playerMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        //Find the gameobject player get the script from it and assign the var to it
        playerMoveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player entered the trigger
        if (collision.CompareTag("Player"))
        {
            //get the respawnPos and set it to this game object
            //updating and changing the respawnPos
            playerMoveScript.respawnPos = this.gameObject;
            
        }
    }
}
