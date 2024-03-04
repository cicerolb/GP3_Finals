using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    [SerializeField] private Transform teleportPosition;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = teleportPosition.transform.position;
        }
    }

}
