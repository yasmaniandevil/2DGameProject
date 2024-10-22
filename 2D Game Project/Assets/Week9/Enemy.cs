using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float shootInterval = 1f;
    public GameObject bulletPrefab;

    private float shootTimer = 0f;

    //textmeshugui is just for canvas text
    //tmp_text is 3D world space
    public TMP_Text enemyHealthText;

    // Start is called before the first frame update
    public virtual void Start()
    {
       UpdateHealthText();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //time.deltatime represents amount of time that has passed since last frame
        //value is added to shoottimer every frame so shoottimer increases
        shootTimer += Time.deltaTime;
        //checks to see if enough time has passed defined by shoot interval if it has it will let you shoot again
        if (shootTimer >= shootInterval)
        {
            Shoot();
            Debug.Log("shot called");
            //countdown can restart for next shot
            shootTimer = 0f;
        }

        //for the first .5seconds player cant shoot as shootTimer is increasing
        //after .5 seconds shoot function is called firing, then timer resets
        //cycle repeats

    }

    public virtual void Shoot()
    {
        if (bulletPrefab != null) // Check if bulletPrefab is assigned
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab is not assigned!");
        }
    }

   

    public void TakeDamage(float damage)
    {
        //subtracting damage from health
        health -= damage;
        UpdateHealthText();
        if(health <= 0)
        {
            //GameOverText
            Destroy(gameObject);
            Debug.Log("Health is 0");

        }
    }

    public void UpdateHealthText()
    {
        enemyHealthText.text = "Health: " + health.ToString();
    }
}
