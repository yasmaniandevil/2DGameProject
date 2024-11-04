using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public float fallTime = 2f;
    public bool playerOnPlatform = false;

     
    // Start is called before the first frame update
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerOnPlatform && fallTime <= 0)
        {
            StartCoroutine(GallingObject());
            playerOnPlatform = false;
        }

        if (playerOnPlatform)
        {
            fallTime -= Time.deltaTime;
        }*/

        if(playerOnPlatform)
        {
            fallTime -=Time.deltaTime;
            if(fallTime < 0)
            {
                StartCoroutine(GallingObject());
                playerOnPlatform = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            fallTime = 2f;
        }
    }

    private IEnumerator GallingObject()
    {
        foreach (Transform childTransform in GetComponentInChildren<Transform>())
        {
            //childTransform.position += new Vector3(0, -2, 0) * 5 * Time.deltaTime;
            childTransform.Translate(Vector3.down * 5 * Time.deltaTime);

            yield return new WaitForSeconds(2);
        }
    }
}
