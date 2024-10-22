using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEnemy : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    //overrid replaces and overrides the shoot method in base class
    public override void Shoot()
    {
        //shoot multiple bullets in spread pattern
        //loop iterates 3 times with i taliing the values -1, 0, and 1
        //i= -1 angles to the left i=0 straight down i = 1 angled to the right
        float angleStep = 10f;
        for(int i = -1; i <= 1; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angleStep * i));
        }
        Debug.Log("called spread enemy shoot");

    }
}
