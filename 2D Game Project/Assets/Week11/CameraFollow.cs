using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followPlayer;
    public float smoothSpeed;
    public Vector3 offsetPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(followPlayer != null)
        {
            Vector3 desiredPos = followPlayer.position + offsetPosition;

            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

            transform.position = smoothPos;
        }
    }
}
