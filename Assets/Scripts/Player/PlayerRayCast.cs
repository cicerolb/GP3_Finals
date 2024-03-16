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
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject itemScreen;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out raycastHit, pickUpDistance, pickUpLayerMask))
        {
            indicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {

                //itemScreen.SetActive(true);


                //indicator.SetActive(false);
                //if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Umbrella"))
                //{
                //    inventoryManager.umbrella = true;
                //    Debug.Log("ashjnkdjkhasd");
                //}

                if (raycastHit.collider.CompareTag("Umbrella"))
                {
                    itemScreen.SetActive(true);
                }

                if (raycastHit.collider.CompareTag("Dumpster"))
                {
                    DumpsterScript dumpsterScript;
                    dumpsterScript = raycastHit.collider.GetComponent<DumpsterScript>();
                    dumpsterScript.dumpsterHide = true;
                }
               
            }
        }
        else if (!Physics.Raycast(cameraPosition.position, cameraPosition.forward, out raycastHit, pickUpDistance, pickUpLayerMask))

        {
            indicator.SetActive(false);
        }
    }

    void DumpsterRayCast()
    {

    }
}
