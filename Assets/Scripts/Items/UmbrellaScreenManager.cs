using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScreenManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject grabAnimation;
    [SerializeField] GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<InventoryManager>();
        playerMovement.cursorLock = false;
        FreezeEntities();
        Debug.Log("jasdjkoasdasd");


    }

    // Update is called once per frame
    void Update()
    {
        indicator.SetActive(false);
        FreezeEntities();
        Time.timeScale = 0f;
    }

    public void Yes()
    {
        inventoryManager.umbrella = true;
        playerMovement.cursorLock = true;
        grabAnimation.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void No()
    {
        UnfreezeEntities();
        playerMovement.cursorLock = true;
        gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void FreezeEntities()
    {
        // Freeze player and AI
        playerMovement.canSprint = false;
        playerMovement.speed = 0;
        playerMovement.canMove = false;
        playerMovement.cursorLock = false;

    }

    public void UnfreezeEntities()
    {
        // Unfreeze player and AI
        playerMovement.canSprint = false;
        playerMovement.speed = 6;
        playerMovement.canMove = true;
        playerMovement.cursorLock = true;
    }
}
