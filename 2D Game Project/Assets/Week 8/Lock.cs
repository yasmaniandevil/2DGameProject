using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public int lockID;
    public Key requiredKey;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        spriteRenderer.color = Color.black;
        Debug.Log("Lock " + lockID + "unlocked!");
    }
}
