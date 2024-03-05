using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopManager : MonoBehaviour
{
    public GameObject teleportPosition;
    bool teleported = false;
    public GameObject player;
    public bool puzzleComplete = false;
    [SerializeField] Object scene;
    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }



    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            if (!puzzleComplete)
            {
                player.SetActive(false);
                player.transform.position = teleportPosition.transform.position;
                player.transform.rotation = teleportPosition.transform.rotation;
                player.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(scene.name);
            }
            
        }
        
    }

}
