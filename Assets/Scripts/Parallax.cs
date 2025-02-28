using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Material[] BgMaterials;
    public float x;
    private float[] parallaxScales;
    public float xScale;
    void Start()
    {
        //creates different scales for the movement of the different layers
        parallaxScales = new float[BgMaterials.Length];

        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = (BgMaterials.Length - i);
        }
    }

    void Update()
    {
        //for testing purposes
        //x will have to be changed to be conencted to the player's x value
        x += Time.deltaTime;

        //causes the layers to be offset by the amount determined by their scales
        for (int i = 0;i < parallaxScales.Length;i++)
        {
            float parallax = parallaxScales[i] * x * xScale;

            Vector2 backgroundTargetPos = new Vector2(parallax, BgMaterials[i].mainTextureOffset.y);

            BgMaterials[i].mainTextureOffset = backgroundTargetPos;
        }
    }
}
