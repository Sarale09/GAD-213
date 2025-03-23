using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Material[] BgMaterials;
    public float direction;
    private float[] parallaxScales;
    public float paralaxSpeed;
    public GameObject witch;
    void Start()
    {
        paralaxSpeed = 0.025f;
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
        if (witch.GetComponent<PlayerMovementWitch>().slowed)
        {
            paralaxSpeed = 0.005f;
        } else
        {
            paralaxSpeed = 0.025f;
        }


        //for testing purposes
        //x will have to be changed to be conencted to the player's x value. currently it moves on its own constantly
        //x += Time.deltaTime;

        //ties the background movement to the player's movement. 
        if (witch.GetComponent<Animator>().GetBool("WalkRight"))
        {
            direction += Time.deltaTime;
        } else if (witch.GetComponent<Animator>().GetBool("WalkLeft"))
        {
            direction -= Time.deltaTime;
        }


        //causes the layers to be offset by the amount determined by their scales
        for (int i = 0;i < parallaxScales.Length;i++)
        {
            float parallax = parallaxScales[i] * direction * paralaxSpeed;

            Vector2 backgroundTargetPos = new Vector2(parallax, BgMaterials[i].mainTextureOffset.y);

            BgMaterials[i].mainTextureOffset = backgroundTargetPos;
        }
    }
}
