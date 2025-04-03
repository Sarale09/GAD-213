using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool overworldView;
    public bool brewView;

    public GameObject overworld;
    public GameObject brew;
    public GameObject inputHandler;
    public GameObject berryPrefab;
    public GameObject berryIngredient;

    public Vector3 spawnPoint;

    public TextMeshProUGUI berryCountText;
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
        countersUpdater();
        brew.SetActive(true);
        inputHandler.GetComponent<InputHandler>().cam = Camera.main;
    }
    public void OverworldViewButton()
    {
        overworldView = true;
        overworld.SetActive(true);
        brewView = false;
        brew.SetActive(false);
        inputHandler.GetComponent<InputHandler>().cam = Camera.main;
    }
    public void countersUpdater()
    {
        berryCountText.text = GetComponent<Inventory>().berryCounter.ToString();
        
        if (GetComponent<Inventory>().berryCounter == 0)
        {
            Color opacityMod = berryIngredient.GetComponent<SpriteRenderer>().color;
            opacityMod.a = 0.5f;
            berryIngredient.GetComponent<SpriteRenderer>().color = opacityMod;
        }
        if (GetComponent<Inventory>().berryCounter > 0)
        {
            Color opacityMod = berryIngredient.GetComponent<SpriteRenderer>().color;
            opacityMod.a = 1f;
            berryIngredient.GetComponent<SpriteRenderer>().color = opacityMod;
        }
    }

    public void addToCauldron()
    {
        spawnPoint = brew.transform.position + new Vector3(Random.Range(1.32f, 7.35f), Random.Range(-2.09f, 0.1f), 1);
        GameObject NewInCauldron = Instantiate(berryPrefab, spawnPoint, Quaternion.identity, brew.transform);
        NewInCauldron.transform.localScale = Vector3.one;
    }
}
