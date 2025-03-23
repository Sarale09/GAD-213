using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleTrigger : MonoBehaviour
{
    public bool onPuddle = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("On puddle");
        onPuddle = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onPuddle = false;
    }
}
