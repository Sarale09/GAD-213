using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Material[] BgMaterials;
    public float x;
    private float[] parallaxScales;
    void Start()
    {
        parallaxScales = new float[BgMaterials.Length];

        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = (BgMaterials.Length - i);
        }
    }

    void Update()
    {
        for (int i = 0;i < parallaxScales.Length;i++)
        {
            float parallax = parallaxScales[i] * x;

            Vector2 backgroundTargetPos = new Vector2(parallax, BgMaterials[i].mainTextureOffset.y);

            BgMaterials[i].mainTextureOffset = backgroundTargetPos;
        }
    }
}
