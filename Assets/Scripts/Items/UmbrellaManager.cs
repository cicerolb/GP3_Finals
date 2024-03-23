using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UmbrellaManager : MonoBehaviour
{
    InventoryManager inventoryManager;
    [SerializeField] string scene;
    [SerializeField] MeshRenderer umbrella;
    [SerializeField] public bool changeScene = false;
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
            umbrella.enabled = false;
            StartCoroutine(ChangeScene());
        }
    }
    
    IEnumerator ChangeScene()
    {
        changeScene = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }
}
