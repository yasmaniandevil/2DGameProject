using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 10f;

    // Update is called once per frame
    void Update()
    {
        //move the bullet down
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //destroy bullet when its off screen
        if(transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Ship>().TakeDamage(damage);
            Debug.Log("took damage");
        }
    }
}
