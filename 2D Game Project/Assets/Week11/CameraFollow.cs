using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //refrence to player
    public Transform followPlayer;
    //how smoothly the camera transitions to the target position
    //higher value will follow player more quickly while lower value will create gradual movement
    public float smoothSpeed;
    //offset from player position
    public Vector3 offsetPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //we use lateupdate bc its called after all other updates
    //often used for camera movement bc it ensures the camera
    //follows the player after any movement logic for player has been processed
    void LateUpdate()
    {
        //checks if it has been assigned
        if(followPlayer != null)
        {
            //calculates the target position the camera should move to
            //creates a new position that considers where the camera is relative to player
            Vector3 desiredPos = followPlayer.position + offsetPosition;
            //lerp smoothly interpolate btwn the current position and the desired position
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            //this line sets the camera position to the new smoothly interpolated position
            transform.position = smoothPos;
        }
    }
}
