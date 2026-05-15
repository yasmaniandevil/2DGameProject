using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float lives;
    public TextMeshProUGUI livesText;

    public bool isShieled = false;
    private float shieldTimer = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        //come back to this later in lesson
        if (isShieled)
        {
            shieldTimer = Time.deltaTime;

            if(shieldTimer <= 0f)
            {
                isShieled = false;
                Debug.Log("Shield expired");
            }
        }
    }

    //first take damage function
    /*public void TakeDamage(float damage)
    {
        
        lives -= damage;
        if(lives < 0)
        {
            lives = 0;
            Debug.Log("Game Over");
            UpdateLivesText();
        }
    }*/

    public void TakeDamage(float damage)
    {
        if(isShieled)
        {
            Debug.Log("player is shielded no damage");
            return;
        }

        //if not shielded apply damage
        lives -= damage;
        if (lives < 0)
        {
            //so lives dont go less than 0
            lives = 0;
            Die();
            UpdateLivesText();
        }

    }

    //this first
    public void UpdateLivesText()
    {

        livesText.text = "Health: " + lives.ToString();
    }

    public void ActivateShield(float duration)
    {
        isShieled = true;
        shieldTimer = duration;

    }

    private void Die()
    {
        Debug.Log("player has died");
    }
}
