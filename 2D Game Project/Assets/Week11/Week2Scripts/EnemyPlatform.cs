using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatform : MonoBehaviour
{
    public float attackCoolDown;//time in seconds before the enemy can attack again
    public float damage; //amount of damage enemy deals
    public float range; //the distance in which the enemy can detect player
    //multiplier for how far the fetection range extends based on collider size
    public float colliderDistance; 
    //timer to track cooldown stars at infinity to allow immediate attack
    private float coolDownTimer = Mathf.Infinity;
    //reference to boxcollider on the enemt, used for collision and range detection
    public BoxCollider2D boxcollider;
    //the layer the player is on to distringush it from other objects
    public LayerMask playerLayer;

    //refrence to the health script on the player
    private Health playerHealth;
    bool isPlayerDamaged = false;
    
    


    // Update is called once per frame
    void Update()
    {
        //increase the timer by the time that has passed
        coolDownTimer += Time.deltaTime;
        //Debug.Log("Cool down timer: " + coolDownTimer);

        //check if player is within the detection range and if the enemy can attack
        if (PlayerInSight() && !isPlayerDamaged)
        {
            Debug.Log("Player in range");
            //if cooldowntimer is greater or equal to attackcooldown, perform attack
            if(coolDownTimer >= attackCoolDown)
            {
                Debug.Log("attack started. cooldown elapsed");
                //reset cooldown timer
                coolDownTimer = 0; //reset timer
                //call the function to damage the player
                DamagePlayer();
                //updates the lives text
                playerHealth.UpdateLivesText();

            }
        }
    }

    //checks if player is in the sight range of enemy using a boxcast
    private bool PlayerInSight()
    {
        //boxcast is a 2D version of a box-shaped raycast, checks if any objects are inside the box
        //perform a boxcast to check if theres an object likeplayer in front of enemy at specific range
        //boxcast(vector 2 origin, vector 2 size, float angle, vector 2 direction, float distance, layer mask)
        RaycastHit2D hit =
            // The position of the center of the box is adjusted by range and collider distance (origin)
            Physics2D.BoxCast(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            // The size of the box cast is based on the collider size and the range multiplier (size)
            new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z),
            //direction box is casted (left) and checks for only objs in playerLayer
            //no angle, direction is cast to the left, distance is 0, and layermask
            0, Vector2.left, 0, playerLayer);
        

        //if a collider is hit by the boxcast (detected something in range)
        if(hit.collider != null)
        {
            Debug.Log("player detected by boxcast hit: " + hit.collider.name);
            //if hit object is player gets health script to apply damage
            playerHealth = hit.transform.GetComponent<Health>();
            
        }
        //returns true if the boxcast hit something. otherwise returns false
        return hit.collider != null;
    }

    //visualizes detection range
    private void OnDrawGizmos()
    {
        //color of gizmo
        Gizmos.color = Color.red;
        //draws wireframe cube representing boxcast's detection range
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z));
    }

    //first do this function before we do shield
    //if player in range damage them
    /*private void DamagePlayer()
    {
        if ((PlayerInSight()))
        {
            Debug.Log("damaging player with: " + damage + "damage!");
            playerHealth.TakeDamage(damage);

            isPlayerDamaged = true;
        }
    }*/

    private void DamagePlayer()
    {
        //if player health script exists
        if((playerHealth != null))
        {
            //and if the player is shielded
            if(playerHealth.isShieled)
            {
                Debug.Log("player is shielded no damage");
                return;
            }

            //if they arent they take damage
            playerHealth.TakeDamage(damage);
            //set damage to true so they dont continue to take damager
            isPlayerDamaged = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //when the player exits isplayerdamage is false so they cant take anymore
            isPlayerDamaged = false;
            Debug.Log("player out of range");
            
        }
    }



}
