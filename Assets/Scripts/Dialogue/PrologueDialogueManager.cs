using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject dialogue3;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject proc_dialogue2;
    [SerializeField] private bool proc_dialogue3;
    [SerializeField] private GameObject friends;
    [SerializeField] private float dist;
    [SerializeField] private GameObject player;
    [SerializeField] private bool hasRun = false;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Start()
    {
        Dialogue1();
    }

    // Update is called once per frame
    void Update()
    {
        Dialogue2Proc();
    }

    void Dialogue2Proc()
    {

        dist = Vector3.Distance(player.transform.position, friends.transform.position);
        if (!hasRun)
        {
            if (dist < 7)
            {
                dialogue2.SetActive(true);
                hasRun = true;
            }
            
            
        }
        
    }

    void Dialogue1()
    {
        dialogue1.SetActive(true);
    }
}
