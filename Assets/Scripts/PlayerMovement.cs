using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            animator.SetBool("WalkRight", true);
            //animator.parameters("WalkRight") = true;
            //animator.Play("Anim_RightTurn");
            //if (Input.GetKey(KeyCode.D))
            //{
            //    animator.Play("Anim_RightWalk");
            //}
            //else
            //{
            //    animator.Play("Idle");
            //}
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("WalkRight", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("WalkLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("WalkLeft", false);
        }


    }
}
