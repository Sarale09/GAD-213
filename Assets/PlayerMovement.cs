using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 3f;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //play animations corresponding to the direction

        if (horizontalInput > 0.5)
        {
            animator.SetBool("WalkRight", true);
        } else if (horizontalInput < -0.5)
        {
            animator.SetBool("WalkLeft", true);
        } else
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
        }

        //walk back and forth
        if (Input.GetKey(KeyCode.W) && transform.position.y < -2.15) //further away
        {
            //Debug.Log("Up");
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S) && transform.position.y > -3.5) // closer
        {
            //Debug.Log("Down");
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
        }
    }
}
