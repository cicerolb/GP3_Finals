using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public bool umbrella = false;
    public bool flashlight = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pelvis && foot && eye){
            allItems = true;
        }
    }
}
