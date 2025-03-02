using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move left when player is moving right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 2, 0) * Time.deltaTime);
        }

        //Move right when player is moving left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, -2, 0) * Time.deltaTime);
        }
    }
}
