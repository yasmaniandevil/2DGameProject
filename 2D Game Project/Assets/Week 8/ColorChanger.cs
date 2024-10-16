using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors; //array to store different colors
    private SpriteRenderer spriteRendy;
    private int currentColorIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendy = GetComponent<SpriteRenderer>();
        spriteRendy.color = colors[currentColorIndex]; //set inital color
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        //move to next color in the array
        currentColorIndex++;

        //if the color index is the same as the length of colors
        //loop back 
        if(currentColorIndex >= colors.Length)
        {
            currentColorIndex = 0;
        }

        spriteRendy.color = colors[currentColorIndex]; //apply the new color

    }
}
