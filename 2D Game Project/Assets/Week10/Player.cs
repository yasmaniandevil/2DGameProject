using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform leftArm;
    public Transform rightArm;

    public int speed = 3;

    void Start()
    {
        Debug.Log("game start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.UpArrow))
        {
            


        }
    }
}
