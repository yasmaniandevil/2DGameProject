using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public float fallTime = 2f;
    public bool playerOnPlatform = false;
    private bool isFalling;
    private List<Vector3> initalPositions = new List<Vector3>();
    private Collider2D parentCollider;
    // Start is called before the first frame update
    void Start()
    {
        //store the inital positions of each child
       foreach(Transform child in transform)
        {
            
            initalPositions.Add(child.localPosition);
        }

        parentCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //check if player is on platform, fallTime has elapsed, and the coroutine hasnt started
        if(playerOnPlatform &&!isFalling)
        {
            fallTime -=Time.deltaTime;
            if(fallTime < 0)
            {
                StartCoroutine(GallingObject());
                Debug.Log("coroutine started");
                isFalling = true; //mark it as started
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            fallTime = 2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            isFalling = false;
            fallTime = 2f;

        }
    }

    private IEnumerator GallingObject()
    {
        parentCollider.enabled = false;

        Rigidbody2D[] childRigidbodies = GetComponentsInChildren<Rigidbody2D>();
        
        foreach(Rigidbody2D rb in childRigidbodies)
        {
            rb.isKinematic = false;
            rb.gravityScale = 1.0f;
            yield return new WaitForSeconds(3);
        }
        isFalling= false;
    }

    public void ResetPlatform()
    {
        StopAllCoroutines();
        parentCollider.enabled = true;
        //loop through each child and reset its position
        for (int i = 0; i < initalPositions.Count; i++)
        {
            Transform child = transform.GetChild(i);
            child.localPosition = initalPositions[i];

            //reset gravity on rigidbodies
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.isKinematic = true;
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
            }

        }
        playerOnPlatform = false;
        fallTime = 2f;
        isFalling = false;
    }

}
