using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("LeftArmDown");
            animator.ResetTrigger("LeftArmDown");
        }

        if(Input.GetKey(KeyCode.Q))
        {
            animator.SetTrigger("LeftArmUp");
            animator.ResetTrigger("LeftArmUp");
        }

        if(Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("RightArmUp");
            animator.ResetTrigger("RightArmUp");
        }

        if(Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("RightArmDown");
            animator.ResetTrigger("RightArmDown");
        }

        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("LeftKick");
            animator.ResetTrigger("LeftKick");
        }

        if(Input.GetKey(KeyCode.X))
        {
            animator.SetTrigger("RightKick");
            animator.ResetTrigger("RightKick");
        }
    }

   

}
