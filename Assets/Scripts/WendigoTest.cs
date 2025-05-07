using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoTest : MonoBehaviour
{
    float moveSpeed = 3f;
    public bool isPaused = false;

    public Vector3 targetPos = new Vector3();  
    // Start is called before the first frame update
    void Start()
    {
        //appears at a random position in the back
        targetPos  = new Vector3 (Random.Range(-1.7f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition == targetPos && isPaused == false) 
        {
            StartCoroutine(MovementPause());
        }

        if (targetPos != null)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator MovementPause()
    {
        isPaused = true;
        Debug.Log("coroutine");
        yield return new WaitForSeconds(3f);
        targetPos = new Vector3(Random.Range(-1.7f, 15.4f), transform.localPosition.y, transform.localPosition.z);
        isPaused = false;
    }
}
