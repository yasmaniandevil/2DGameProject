using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float shootInterval = 1f;
    public GameObject bulletPrefab;

    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            Debug.Log("shot called");
            shootTimer = 0f;
        }

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
        health -= damage;
        if(health <= 0)
        {
            //GameOverText

        }
    }
}
