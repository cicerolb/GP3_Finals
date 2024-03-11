using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UmbrellaManager : MonoBehaviour
{
    InventoryManager inventoryManager;
    [SerializeField] Object scene;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryManager.umbrella == true)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
