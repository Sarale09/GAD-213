using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        //walk right if pressing D
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("WalkRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("WalkRight", false);
        }

        //walk left if pressing A
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("WalkLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("WalkLeft", false);
        }

        //walk further away
        if (Input.GetKey(KeyCode.W) && transform.position.y < -2)
        {
            //Debug.Log("Up");
            transform.Translate(new Vector3(0,1,0) * Time.deltaTime);
            transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
        }

        //walk closer
        if (Input.GetKey(KeyCode.S) && transform.position.y > -3.25)
        {
            //Debug.Log("Down");
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            transform.localScale += new Vector3(0.3f,0.3f,0.3f) * Time.deltaTime;
        }

    }
}
