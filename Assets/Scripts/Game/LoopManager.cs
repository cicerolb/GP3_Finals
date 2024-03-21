using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopManager : MonoBehaviour
{
    public Animator animator;
    public GameObject player, spawn;

    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Object scene;

    void Awake(){
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }
    void Start()
    {
        GameObject fadeUI = GameObject.Find("BlackFade");
        animator = fadeUI.GetComponent<Animator>();

        animator.SetBool("FadeOut", true);
    }

    IEnumerator LoadSceneAfterFade(string sceneName)
    {
        // Wait for the fade animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        // Load the next scene
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name != "Loop 5"){
            if (other.CompareTag("Player"))
            {
            // Trigger fade-out animation
            animator.SetBool("FadeOut", false);

            // Start coroutine to load scene after fade animation finishes
            StartCoroutine(LoadSceneAfterFade(scene.name));
            }
        }
        else{
            if (other.CompareTag("Player") && !inventoryManager.allItems){
                player.SetActive(false);
                player.transform.position = spawn.transform.position;
                player.SetActive(true);
            }
            else if (other.CompareTag("Player") && inventoryManager.allItems){
                animator.SetBool("FadeOut", false);
                StartCoroutine(LoadSceneAfterFade(scene.name));
            }
            
        }
        
        

    }

}
