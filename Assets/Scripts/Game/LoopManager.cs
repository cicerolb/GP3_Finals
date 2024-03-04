using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    [SerializeField] private Transform teleportPosition;
    bool teleported = false;
    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!teleported)
            {
                transform.position = teleportPosition.transform.position;
                teleported = true;
                
            }
            teleported = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            
        }
    }
    


}
