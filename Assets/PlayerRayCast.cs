using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float pickUpDistance;
    private RaycastHit raycastHit;
    [SerializeField] private GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out raycastHit, pickUpDistance, pickUpLayerMask))
        {
            Debug.Log("hdjkashd");
        }
    }
}
