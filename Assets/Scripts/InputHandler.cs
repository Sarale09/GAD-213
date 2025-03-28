using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private Camera cam;
    public Inventory inventory;

    private void Awake()
    {
        cam = Camera.main;
        inventory = FindObjectOfType<Inventory>();
    }

   public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider || rayHit.collider.gameObject.tag != "Interactable") return;

        //Debug.Log(rayHit.collider.gameObject.name);
        if (rayHit.collider.gameObject.name.Contains("Berry"))
        {
            inventory.berryCounter += 1;
            Destroy(rayHit.collider.gameObject);
        }
        
    }
}
