using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScreenManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] EnemyAI enemyAI;
    [SerializeField] InventoryManager inventoryManager;
    // Start is called before the first frame update

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<InventoryManager>();
        FreezeEntities();
        playerMovement.cursorLock = false;

        Debug.Log("jasdjkoasdasd");
        enemyAI = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        if (gameObject.name == "Umbrella Item")
        {
            inventoryManager.umbrella = true;
        }
        UnfreezeEntities();
        playerMovement.cursorLock = true;
        gameObject.SetActive(false);
    }

    public void No()
    {
        UnfreezeEntities();
        playerMovement.cursorLock = true;
        gameObject.SetActive(false);
    }

    public void FreezeEntities()
    {
        // Freeze player and AI
        playerMovement.canSprint = false;
        playerMovement.speed = 0;

        enemyAI.speedRun = 0;
        enemyAI.speedWalk = 0;
    }

    public void UnfreezeEntities()
    {
        // Unfreeze player and AI
        playerMovement.canSprint = false;
        playerMovement.speed = 6;

        enemyAI.speedRun = 6;
        enemyAI.speedWalk = 9;
    }
}
