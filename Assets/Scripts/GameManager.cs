using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool overworldView;
    public bool brewView;

    public GameObject overworld;
    public GameObject brew;
    // Start is called before the first frame update
    void Start()
    {
        overworldView = true;
        brewView = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BrewViewButton()
    {
        overworldView = false;
        overworld.SetActive(false);
        brewView = true;
        brew.SetActive(true);
    }
    public void OverworldViewButton()
    {
        overworldView = true;
        overworld.SetActive(true);
        brewView = false;
        brew.SetActive(false);
    }
}
