using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoTest : MonoBehaviour
{
    float moveSpeed = 3f;
    public bool isPaused = false;
    public bool hunting = false;
    public int movements;
    private Animator animator;
    private SpriteRenderer rend;
    public Vector3 targetPos = new Vector3();  
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

        //appears at a random position in the back
        targetPos = new Vector3 (Random.Range(-1.7f, 15.4f), 1.72f, transform.localPosition.z);
        transform.localPosition = targetPos;
        transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
    }

    private void OnEnable()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //creates a new target position once the wendigo has reached its previous target
        if (transform.localPosition == targetPos && isPaused == false && hunting == false) 
        {
            switch (movements)
            {
                case 10:
                    rend.sortingLayerName = "Middle Trees";
                    transform.localScale = new Vector3(0.625f, 0.625f, 0.625f);
                    transform.localPosition = new Vector3(transform.localPosition.x, 1.3f, transform.localPosition.z);
                    break;
                case 20:
                    rend.sortingLayerName = "Front Trees";
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                    transform.localPosition = new Vector3(transform.localPosition.x, 1.45f, transform.localPosition.z);
                    break;
                case 30:
                    rend.sortingLayerName = "Interactable";
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.localPosition = new Vector3(14.5f, 0.6f, transform.localPosition.z);
                    hunting = true;
                    Debug.Log("Hunting");
                    break;

            }

            StartCoroutine(MovementPause());

        }

       
        if (hunting == false)
        {
            //moves the wendigo
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);

            //determines animation to play based on direction
            if (targetPos.x > transform.localPosition.x)
            {
                animator.SetBool("WalkingRight", true);
            }
            else if (targetPos.x < transform.localPosition.x)
            {
                animator.SetBool("WalkingLeft", true);
            }
        }

        if (hunting)
        {
            //when hunting the wendigo will move towards the player
            animator.SetBool("WalkingLeft", true);
            targetPos = new Vector3 (0, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
            if (transform.localPosition == targetPos)
            {
                //Display loss screen
                manager.GetComponent<GameManager>().lost = true;
            }
        }

    }

    IEnumerator MovementPause()
    {
        // waits for 3 seconds at his current location before finding a new target position
        isPaused = true;
        //Debug.Log("coroutine");
        animator.SetBool("WalkingRight", false);
        animator.SetBool("WalkingLeft", false);
        movements += 1;
        yield return new WaitForSeconds(3f);
        targetPos = new Vector3(Random.Range(-1.7f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        isPaused = false;
    }
}
