using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] items;
    public bool[] itemsStatus;
    public bool umbrella = false;

    public bool pelvis = false;
    public bool foot = false;
    public bool eye = false;

    public bool allItems = false;

    [Header("Wheels")]
    public bool wheel1 = false;
    public bool wheel2 = false;
    public bool wheel3 = false;
    public bool wheel4 = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Loop 5"){
            pelvis = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pelvis && foot && eye){
            allItems = true;
        }

        ItemCheck();
    }

    void ItemCheck(){
        for (int i = 0; i < items.Length; i++)
        {
            if (items.Length > 0)
            {
                if (items != null){
                ItemScript itemScript = items[i].GetComponent<ItemScript>();
                if (itemScript.pickedUp)
                {
                    itemsStatus[i] = true;
                }
                }
                
            }
            
        }
    }
}
