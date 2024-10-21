using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthText();
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        Debug.Log("called shooting fast enemy");
        shootInterval = 1f;
        base.Shoot();
    }
}
