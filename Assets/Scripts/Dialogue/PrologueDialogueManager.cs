using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Dialogues
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject dialogue3;
    [SerializeField] private GameObject dialogue4;
    // ---

    // Other Scripts
    [SerializeField] private UmbrellaManager umbrellaManager;


    [SerializeField] private GameObject proc_dialogue2;
    [SerializeField] private bool proc_dialogue3;
    [SerializeField] private GameObject friends;
    [SerializeField] private float dist;
    [SerializeField] private GameObject player;
    [SerializeField] private bool hasRun = false;
    [SerializeField] private GameObject umbrellaTable;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Dialogue1();
    }

    // Update is called once per frame
    void Update()
    {
        Dialogue2Proc();
        Dialogue3Proc();
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
                umbrellaTable.SetActive(true);

            }


        }
        
    }
    public void Dialogue3Proc()
    {
        umbrellaManager = GameObject.Find("Umbrella").GetComponent<UmbrellaManager>();

        if (umbrellaManager.changeScene == true)
        {
            dialogue3.SetActive(true);
            umbrellaManager.changeScene = false;
        }

    }

    void Dialogue1()
    {
        dialogue1.SetActive(true);
    }
}
