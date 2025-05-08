using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool overworldView;
    public bool brewView;
    public bool lost = false;

    public GameObject overworld;
    public GameObject lossScreen;
    public GameObject brew;
    public GameObject inputHandler;
    public GameObject berryPrefab;
    public GameObject brewButton;
    public GameObject potionViewButton;
    public GameObject ingredientViewButton;
    public GameObject ingredientView;
    public GameObject potionView;

    public GameObject berryIngredient;
    public GameObject berryPotion;
    public GameObject overworldPotion;
    public GameObject usePotionUI;

    public Inventory inventory;

    public List<GameObject> inCauldron = new List<GameObject>();

    public Vector3 spawnPoint;

    public TextMeshProUGUI berryCountText;
    public TextMeshProUGUI berryPotionText;
    public TextMeshProUGUI overworldPotionText;
    // Start is called before the first frame update
    void Start()
    {
        overworldView = true;
        brewView = false;
        inventory = GetComponent<Inventory>();
        countersUpdater();
    }

    private void Update()
    {
        if (lost)
        {
            overworld.SetActive(false);
            lossScreen.SetActive(true);
        }
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
        UpdateCounter("berries", berryCountText, berryIngredient);
        UpdateCounter("berry potions", berryPotionText, berryPotion);
        UpdateCounter("berry potions", overworldPotionText, overworldPotion);
    }

    public void addToCauldron()
    {
        //spawns the selected ingredient at a random position inside the cauldron
        spawnPoint = brew.transform.position + new Vector3(Random.Range(1.32f, 7.35f), Random.Range(-2.09f, 0.1f), 1);
        GameObject NewInCauldron = Instantiate(berryPrefab, spawnPoint, Quaternion.identity, brew.transform);
        NewInCauldron.transform.localScale = Vector3.one;

        //adds the object to the in cauldron list to keep tract of what has been selected
        inCauldron.Add(NewInCauldron);
        //Debug.Log(inCauldron.Count);

        if (inCauldron.Count == 3)
        {
            brewButton.SetActive(true);
        }
    }

    public void BrewPotionButton()
    {
        List<GameObject> berriesInCauldron = inCauldron.FindAll(x => x.name.ContainsInsensitive("berry"));
        if (berriesInCauldron.Count == 3)
        {
            //destroy all objects in the cauldron
            for (int i = 0; i < 3; i++)
            {
                Destroy(berriesInCauldron[i]);
                //Debug.Log(inCauldron.Count);
            }

            //clear the list
            inCauldron.Clear();
            //Debug.Log(inCauldron.Count);

            //add potion to inventory
            inventory.berryPotion++;

            //hide brew button
            brewButton.SetActive(false);

            //update counters
            countersUpdater();
        }
    }

    private void UpdateCounter(string item, TextMeshProUGUI itemText, GameObject itemSprite)
    {
        int invCheck = 0;
        if (item == "berries")
        {
            invCheck = inventory.berryCounter;
        } else if (item == "berry potions")
        {
            invCheck = inventory.berryPotion;
        }

        itemText.text = invCheck.ToString();


        if (invCheck == 0)
        {
            Color opacityMod = itemSprite.GetComponent<SpriteRenderer>().color;
            opacityMod.a = 0.5f;
            itemSprite.GetComponent<SpriteRenderer>().color = opacityMod;
            usePotionUI.SetActive(false);
        }
        if (invCheck > 0)
        {
            Color opacityMod = itemSprite.GetComponent<SpriteRenderer>().color;
            opacityMod.a = 1f;
            itemSprite.GetComponent<SpriteRenderer>().color = opacityMod;
            usePotionUI.SetActive(true);
        }

    }

    public void PotionViewButton() 
    {
        berryPotion.SetActive(true);
        potionView.SetActive(true);
        berryIngredient.SetActive(false);
        ingredientView.SetActive(false);
    }
    public void IngredientViewButton()
    {
        berryPotion.SetActive(false);
        potionView.SetActive(false);
        berryIngredient.SetActive(true);
        ingredientView.SetActive(true);
    }
}
