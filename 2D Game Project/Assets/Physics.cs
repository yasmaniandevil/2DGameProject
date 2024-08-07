using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{

    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        Transform playerTransform = player.transform;
        Vector2 pos = playerTransform.position;
        Debug.Log(pos);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
