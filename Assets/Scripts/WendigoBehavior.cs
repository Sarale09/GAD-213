using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoBehavior : MonoBehaviour
{
    float moveSpeed = 10f;
    Rigidbody2D rb;
    Animator animator;
    private Vector3 targetPos;
    private Vector3 referenceVelocity = Vector3.zero;
    public GameObject Witch;
    public Coroutine changePosCoroutine = null;
    public bool shouldMove;
    public bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        shouldMove = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(Random.Range(-1.6f, 15.4f), transform.position.y, transform.position.z);
        //if (changePosCoroutine == null)
        //{
        //    changePosCoroutine = StartCoroutine(ChangePos());
        //}
    }

    // Update is called once per frame
    void Update()
    {


        //wendigo movement
        //if (Witch.GetComponent<PlayerMovement>().isWalking)
        //{
        //    Witch.GetComponent<PlayerMovement>().isWalking = false;
        //    targetPos = new Vector3(Random.Range(-1.6f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        //    transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        //    //transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPos, ref referenceVelocity, moveSpeed);
        //}
        if (shouldMove && changePosCoroutine == null)
        {
            Debug.Log("test");
            shouldMove = false;
            Witch.GetComponent<PlayerMovement>().isWalking = false;
            targetPos = new Vector3(Random.Range(-1.6f, 15.4f), transform.localPosition.y, transform.localPosition.z);
            if (transform.localPosition != targetPos)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
            }
            //transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPos, ref referenceVelocity, moveSpeed);
            changePosCoroutine = StartCoroutine(ChangePos());
        }


        //Bounds wendigo  to screen  limit
        if (transform.localPosition.x > 17.3f)
        {
            transform.localPosition = new Vector3(17.3f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x < -3.7f)
        {
            transform.localPosition = new Vector3(-3.7f, transform.localPosition.y, transform.localPosition.z);
        }
    }

    IEnumerator ChangePos()
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(5f);
        shouldMove = true;
        yield return null;

        //    while (shouldMove)
        //    {
        //        Debug.Log("Moving");
        //        yield return new WaitForSeconds(5f);
        //        targetPos = transform.localPosition + new Vector3(Random.Range(-1.6f, 15.4f), 0, 0);
        //        //targetPos = new Vector3(Random.Range(-1.6f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        //        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        //        Debug.Log(targetPos);
        //        Debug.Log(transform.localPosition);
        //    }

    }
    }
