using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;

public class ItemScreenManager : MonoBehaviour
{
    // Scripts
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] InventoryManager inventoryManager;

    [Header("GameObjects")]
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject grab;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        indicator = GameObject.Find("Indicator");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        indicator.SetActive(false);
        Time.timeScale = 0f;   
    }

    public void Take()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (gameObject.name == "PelvisScreen")
        {
            inventoryManager.pelvis = true;
        }
        else if (gameObject.name == "UmbrellaScreen"){
            inventoryManager.umbrella = true;
        }
        gameObject.SetActive(false);
        grab.SetActive(true);
        
        Time.timeScale = 1f;
    }
}
