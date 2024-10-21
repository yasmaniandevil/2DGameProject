using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        //shoot multiple bullets in spread pattern
        float angleStep = 10f;
        for(int i = -1; i <= 1; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angleStep * i));
        }

    }
}
