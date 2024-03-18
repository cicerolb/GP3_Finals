using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BusPuzzleManager : MonoBehaviour
{
    Outline outline;

    InventoryManager inventoryManager;
    Interactable interactable;

    [Header("Wheels")]
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    public GameObject wheel4;

    [Header("Wheels Mesh Renderer")]
    private MeshRenderer wheel1Renderer;
    private MeshRenderer wheel2Renderer;
    private MeshRenderer wheel3Renderer;
    private MeshRenderer wheel4Renderer;

    [SerializeField] private Transform playerCameraTransform;
    PlayerInteraction playerInteraction;

    public bool puzzleDone = false;

    private void Start()
    {
        wheel1Renderer = wheel1.GetComponent<MeshRenderer>();
        wheel2Renderer = wheel2.GetComponent<MeshRenderer>();
        wheel3Renderer = wheel3.GetComponent<MeshRenderer>();
        wheel4Renderer = wheel4.GetComponent<MeshRenderer>();

        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        playerInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
        interactable = GameObject.FindObjectOfType<Interactable>().GetComponent<Interactable>();
        outline = GetComponent<Outline>();

        DisableWheelRenderers();
    }

    private void Update()
    {
        if (puzzleDone)
        {
            //DisableWheelOutlines();
            playerInteraction.enabled = false;
            interactable.enabled = false;
            HUDPickup.instance.DisableInteractionText(); 
            Debug.Log("Player interaction, Interactable, HUDPickup text, and outline disabled.");
        }
    }

    public void PutWheel()
    {
        //checks if raycast hits within playerReach
        RaycastHit hit;
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, playerInteraction.playerReach))
        {
            //gets interactable component on raycast hit
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null && interactable.tag == "BusWheel")
            {
                //checks if all wheels are collected
                if (inventoryManager.wheel1 && inventoryManager.wheel2 && inventoryManager.wheel3 && inventoryManager.wheel4)
                {
                    //debugs interacting with wheel
                    Debug.Log("Placing wheel on bus.");
                    MeshRenderer wheelRenderer = interactable.GetComponent<MeshRenderer>();
                    //handles enabling wheelRenderers
                    if (wheelRenderer != null)
                    {
                        wheelRenderer.enabled = true;

                        if (wheel1Renderer.enabled && wheel2Renderer.enabled && wheel3Renderer.enabled && wheel4Renderer.enabled)
                        {
                            puzzleDone = true;
                            Debug.Log("Setting Puzzle Done to True");
                        }
                    }
                }
            }
        }
    }

    private void DisableWheelRenderers()
    {
        wheel1Renderer.enabled = false;
        wheel2Renderer.enabled = false;
        wheel3Renderer.enabled = false;
        wheel4Renderer.enabled = false;
    }

    //private void DisableWheelOutlines()
    //{
    //    DisableOutline(wheel1);
    //    DisableOutline(wheel2);
    //    DisableOutline(wheel3);
    //    DisableOutline(wheel4);
    //}

    //private void DisableOutline(GameObject wheel)
    //{
    //    // Check if the wheel has an Outline component attached
    //    Outline outline = wheel.GetComponent<Outline>();
    //    if (outline != null)
    //    {
    //        outline.enabled = false;
    //    }
    //}
}
