using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryManager.pelvis == true && gameObject.name == "Pelvis")
        {
            gameObject.SetActive(false);
        }
        else if (inventoryManager.foot == true && gameObject.name == "Foot")
        {
            gameObject.SetActive(false);
        }
    }
}
