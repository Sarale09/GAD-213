using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoTest : MonoBehaviour
{
    float moveSpeed = 3f;
    public bool isPaused = false;
    private Animator animator;
    public Vector3 targetPos = new Vector3();  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //appears at a random position in the back
        targetPos = new Vector3 (Random.Range(-1.7f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        //creates a new target position once the wendigo has reached its previous target
        if (transform.localPosition == targetPos && isPaused == false) 
        {
            StartCoroutine(MovementPause());
        }

        //moves the wendigo
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);

        //determines animation to play based on direction
        if (targetPos.x > transform.localPosition.x)
        {
            animator.SetBool("WalkingRight", true);
        } else if (targetPos.x < transform.localPosition.x)
        {
            animator.SetBool("WalkingLeft", true);
        }
      
    }

    IEnumerator MovementPause()
    {
        // waits for 3 seconds at his current location before finding a new target position
        isPaused = true;
        //Debug.Log("coroutine");
        animator.SetBool("WalkingRight", false);
        animator.SetBool("WalkingLeft", false);
        yield return new WaitForSeconds(3f);
        targetPos = new Vector3(Random.Range(-1.7f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        isPaused = false;
    }
}
