using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInteraction : MonoBehaviour
{
    InventoryManager inventoryManager;

    Outline outline;

    public float playerReach = 3f;
    Interactable currentInteractable;
    [SerializeField] private Transform playerCameraTransform;

    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractable.SetInteracted(true);

            //interacting with wheel sets SetInteracted to true
            GameObject interactedWheel = currentInteractable.gameObject;
            if (interactedWheel.name == "Interactable Wheel 1")
            {
                inventoryManager.wheel1 = true;
                Debug.Log("Interacted with Interactable Wheel 1, setting SetInteracted to true");
            }
            else if (interactedWheel.name == "Interactable Wheel 2")
            {
                inventoryManager.wheel2 = true;
                Debug.Log("Interacted with Interactable Wheel 2, setting SetInteracted to true");
            }
            else if (interactedWheel.name == "Interactable Wheel 3")
            {
                inventoryManager.wheel3 = true;
                Debug.Log("Interacted with Interactable Wheel 3, setting SetInteracted to true");
            }
            else if (interactedWheel.name == "Interactable Wheel 4")
            {
                inventoryManager.wheel4 = true;
                Debug.Log("Interacted with Interactable Wheel 4, setting SetInteracted to true");
            }

            
        }

        CheckInteraction();
    }

    public void CheckInteraction()
    {
        //checks if player has all 4 wheels
        if (inventoryManager.wheel1 && inventoryManager.wheel2 && inventoryManager.wheel3 && inventoryManager.wheel4)
        {
            //if the player has all wheels, enable interaction with only BusWheel
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, playerReach))
            {
                if (raycastHit.collider.tag == "BusWheel")
                {
                    Interactable newInteractable = raycastHit.collider.GetComponent<Interactable>();
                    if (currentInteractable && newInteractable != currentInteractable)
                    {
                        currentInteractable.DisableOutline();
                    }
                    if (newInteractable != null && newInteractable.enabled)
                    {
                        SetNewCurrentInteractable(newInteractable);
                    }
                    else
                    {
                        DisableCurrentInteractable();
                    }
                    // Enable BusWheel text
                    HUDPickup.instance.EnableInteractionText(currentInteractable.message);
                }
                else
                {
                    DisableCurrentInteractable();
                    HUDPickup.instance.DisableInteractionText();
                }
            }
            else
            {
                DisableCurrentInteractable();
                HUDPickup.instance.DisableInteractionText();
            }
        }
        else
        {
            // if player doesnt have all 4 wheels, only interact with WheelInteractable
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, playerReach))
            {
                if (raycastHit.collider.tag == "WheelInteractable")
                {
                    Interactable newInteractable = raycastHit.collider.GetComponent<Interactable>();
                    if (currentInteractable && newInteractable != currentInteractable)
                    {
                        currentInteractable.DisableOutline();
                    }
                    if (newInteractable != null && newInteractable.enabled)
                    {
                        SetNewCurrentInteractable(newInteractable);
                    }
                    else
                    {
                        DisableCurrentInteractable();
                    }
                    HUDPickup.instance.EnableInteractionText(currentInteractable.message);
                }
                else
                {
                    DisableCurrentInteractable();
                    HUDPickup.instance.DisableInteractionText();
                }
            }
            else
            {
                DisableCurrentInteractable();
                HUDPickup.instance.DisableInteractionText();
            }
        }
    }

    public void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        //currentInteractable.EnableOutline();
        HUDPickup.instance.EnableInteractionText(currentInteractable.message);

        Debug.Log("New current interactable set: " + currentInteractable.name);
    }


    public void DisableCurrentInteractable()
    {

        HUDPickup.instance.DisableInteractionText();
        if (currentInteractable)
        {
            //currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }

}
