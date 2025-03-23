using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTest : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public GameObject puddle;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         float distance = cam.transform.position.x * parallaxEffect; // 0 =move with camera || 1 = wont move || 0.5 = half speed
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3 (startPos + distance, 0, transform.position.z);
        if (movement > startPos+length)
        {
            startPos += length;
        } else if (movement < startPos-length)
        {
            startPos -= length;
        }
    }
}
