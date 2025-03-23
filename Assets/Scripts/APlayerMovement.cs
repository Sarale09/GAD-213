using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementWitch : MonoBehaviour
{
    public bool slowed = false;
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

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.tag == "Puddle")
        {
            slowed = true;
            Debug.Log("Collision Working.");
            animator.speed = 0.3f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puddle")
        {
            slowed = false;
            animator.speed = 1;
        }
    }

}
