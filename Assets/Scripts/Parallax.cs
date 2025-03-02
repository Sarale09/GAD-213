using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Material[] BgMaterials;
    public float x;
    private float[] parallaxScales;
    public float xScale;
    public GameObject witch;
    void Start()
    {
        xScale = 0.025f;
        //creates different scales for the movement of the different layers
        parallaxScales = new float[BgMaterials.Length];

        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = (BgMaterials.Length - i);
        }
    }

    void Update()
    {
        //Changes the speed at which the background is moving when the player is slowed down
        if (witch.GetComponent<PlayerMovement>().slowed)
        {
            xScale = 0.005f;
        } else
        {
            xScale = 0.025f;
        }


        //for testing purposes
        //x will have to be changed to be conencted to the player's x value. currently it moves on its own constantly
        //x += Time.deltaTime;

        //ties the background movement to the player's movement. 
        if (witch.GetComponent<Animator>().GetBool("WalkRight"))
        {
            x += Time.deltaTime;
        } else if (witch.GetComponent<Animator>().GetBool("WalkLeft"))
        {
            x -= Time.deltaTime;
        }


        //causes the layers to be offset by the amount determined by their scales
        for (int i = 0;i < parallaxScales.Length;i++)
        {
            float parallax = parallaxScales[i] * x * xScale;

            Vector2 backgroundTargetPos = new Vector2(parallax, BgMaterials[i].mainTextureOffset.y);

            BgMaterials[i].mainTextureOffset = backgroundTargetPos;
        }
    }
}
