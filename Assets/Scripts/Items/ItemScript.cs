using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private GameObject popUpScreen;
    [SerializeField] public bool pickedUp = false;
    private PlayerMovement playerMovement;
    private PlayerHandSprites playerHand;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerHand = GameObject.Find("Player").GetComponent<PlayerHandSprites>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp){
            Collider collider = GetComponent<Collider>();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            collider.enabled = false;
            meshRenderer.enabled = false;
        }

        playerMovement.canMove = !popUpScreen.activeSelf;
    }

    public void IteminteractedFunction(){
        popUpScreen.SetActive(true);
    }

    public void Yes(){
        pickedUp = true;
        playerHand.grab.SetActive(true);
        popUpScreen.SetActive(false);
    }

    public void No(){
        popUpScreen.SetActive(false);
    }
}
