using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float bulletDamage = 10f;
    public float bulletSpeed = 5f;
    private float direction = 1f;
    
    
    public void SetDirection(float newDirection)
    {
        direction = newDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collison enter");

        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            Debug.Log("found enemy");
            Destroy(collision.gameObject);
            //Destroy(gameObject);

        }
    }


}
