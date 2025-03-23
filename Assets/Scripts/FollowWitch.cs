using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWitch : MonoBehaviour
{
    public GameObject Witch;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Witch.transform.position.x, transform.position.y, transform.position.z) ;
    }
}
