using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private LayerMask hideLayerMask;
    [SerializeField] private float pickUpDistance;
    private RaycastHit raycastHit;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject umbrellaScreen;
    [SerializeField] private GameObject pelvisScreen;
    [SerializeField] private GameObject footScreen;
    [SerializeField] private GameObject eyeScreen;


    // Other Scripts
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] DumpsterScript currentDumpster;
    [SerializeField] SewerScript currentSewer;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemPickUp();


        // if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out raycastHit, pickUpDistance, pickUpLayerMask))
        // {
        //     indicator.SetActive(true);
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {

        //         if (raycastHit.collider.CompareTag("Umbrella"))
        //         {
        //             umbrellaScreen.SetActive(true);
        //         }
        //         else if (raycastHit.collider.CompareTag("Dumpster"))
        //         {
        //             currentDumpster = raycastHit.collider.GetComponent<DumpsterScript>();
        //             if (currentDumpster != null)
        //             {
        //                 currentDumpster.enterDumpsterStart = true;
        //             }
        //         }
        //         else if (raycastHit.collider.CompareTag("Sewer"))
        //         {
        //             currentSewer = raycastHit.collider.GetComponent<SewerScript>();
        //             if (currentSewer != null)
        //             {
        //                 currentSewer.enterSewerStart = true;
        //             }
        //         }
        //         else if (raycastHit.collider.CompareTag("Pelvis"))
        //         {
        //             pelvisScreen.SetActive(true);
        //         }
        //         else if (raycastHit.collider.CompareTag("Foot"))
        //         {
        //             footScreen.SetActive(true);
        //         }
        //         else if (raycastHit.collider.CompareTag("Eye"))
        //         {
        //             eyeScreen.SetActive(true);
        //         }
               
        //     }
        // }
        // else if (!Physics.Raycast(cameraPosition.position, cameraPosition.forward, out raycastHit, pickUpDistance, pickUpLayerMask))

        // {
        //     indicator.SetActive(false);
        // }
    }

    void ItemPickUp(){
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out raycastHit, pickUpDistance, pickUpLayerMask)){
            indicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)){
                ItemScript itemScript = raycastHit.collider.GetComponent<ItemScript>();
                if (itemScript != null){
                    itemScript.IteminteractedFunction();
                }
            }
        }
        else{
            indicator.SetActive(false);
        }
    }

}
