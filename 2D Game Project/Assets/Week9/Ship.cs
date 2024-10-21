using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ship : MonoBehaviour
{
    public float forceAmount = 2f;
    private Rigidbody2D rb2d;

    public GameObject playerBulletPrefab;
    public Transform bulletSpawnPoint;

    public float boundary;
    public float health;

    public float shootTimer = 0f;
    public float shootInterval = .5f;

    public TextMeshProUGUI healthText;
    public float gameTimer = 60f;
    public TMP_Text winText;
    public TMP_Text timerText;

 

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector3.left * forceAmount);
            
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector3.right * forceAmount);
            
        }

        float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
        transform.position = new Vector2(clampedX, transform.position.y);

        shootTimer += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space) && shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }

        UpdateTimer();
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        UpdateHealthText();
        if (health <= 0)
        {
            
            //GameOverText
            Debug.Log("Health: " + health);

        }
    }

    void Shoot()
    {
        Instantiate(playerBulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void UpdateTimer()
    {
        gameTimer -= Time.deltaTime;

        if(timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(gameTimer).ToString();
        }

        if(gameTimer < 0f)
        {
            gameTimer = 0f;
            Time.timeScale = 0f;
            
            if(health > 50)
            {
                winText.gameObject.SetActive(true);
                winText.text = "YOU WON";
            }

            if(health < 50)
            {
                winText.gameObject.SetActive(true);
                winText.text = "YOU LOST";
            }
        }
    }
}
