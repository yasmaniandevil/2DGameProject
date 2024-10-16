using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInvetory : MonoBehaviour
{
    //list to store collected items
    public List <string> collectedItems = new List <string> ();

    public TextMeshProUGUI inventoryText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            collectedItems.Add(collision.GetComponent<Collectible>().itemName);
            Debug.Log("collected: " + collision.GetComponent<Collectible>().itemName);
            UpdateInventoryUI();
            Destroy(collision.gameObject);
            
        }
    }

    private void UpdateInventoryUI()
    {
        inventoryText.text = "Collected Items:\n" + string.Join("\n", collectedItems);

        if(collectedItems.Count >= 4)
        {
            inventoryText.text = "Game Over";
        }
    }


}
