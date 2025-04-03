using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    public Camera cam;
    public Inventory inventory;
    public GameManager manager;

    private void Awake()
    {
        cam = Camera.main;
        inventory = FindObjectOfType<Inventory>();
    }

   public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        //Debug.Log(rayHit.collider.gameObject.name);

        //interactions when picking up an item in the overworld
        if (rayHit.collider.gameObject.tag == "PickUp")
        {
            //if statement created to allow for the expansion of various ingredients
            if (rayHit.collider.gameObject.name.Contains("Berry"))
            {
                inventory.berryCounter += 1;
                manager.GetComponent<GameManager>().countersUpdater();
                Destroy(rayHit.collider.gameObject);
                //When removing an item from the cauldron 
                if (manager.brewView)
                {
                    manager.inCauldron.Remove(rayHit.collider.gameObject);
                    manager.brewButton.SetActive(false);
                    //Debug.Log(manager.inCauldron.Count);
                }
            }
        }

        //interactions when usign ingredients in brew view
        if (rayHit.collider.gameObject.tag == "Ingredient" && inventory.berryCounter > 0 && manager.inCauldron.Count < 3)
        {
            inventory.berryCounter -= 1;
            manager.GetComponent<GameManager>().countersUpdater();
            manager.GetComponent<GameManager>().addToCauldron();
        }



    }
}
