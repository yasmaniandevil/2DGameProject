using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //how long the powerUp lasts
    public float duration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check the tag
        if (collision.CompareTag("Player"))
        {
            //activate function power up in player script
            collision.GetComponent<InputMovement>().ActivatePowerUp(duration);
            
            //destroy powerup after collecting
            Destroy(gameObject);
        }
    }
}
