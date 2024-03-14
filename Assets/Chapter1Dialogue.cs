using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Dialogue : MonoBehaviour
{
    // Dialogues
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject dialogue3;
    [SerializeField] private GameObject dialogue4;
    // ---

    // Objectives
    [SerializeField] private GameObject objective1;
    [SerializeField] private GameObject objective2;

    // Other Scripts
    [SerializeField] private ObjectiveSkip objectiveSkip;

    [SerializeField] private GameObject friends;
    [SerializeField] private float dist;
    [SerializeField] private GameObject player;
    [SerializeField] private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectiveSkip = GameObject.Find("ObjectiveSkip").GetComponent<ObjectiveSkip>();
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
                objectiveSkip.nextObjective = true;
                dialogue2.SetActive(true);
                hasRun = true;
                objective2.SetActive(true);

            }


        }

    }
    public void Dialogue3Proc()
    {

    }

    void Dialogue1()
    {
        objective1.SetActive(true);
        dialogue1.SetActive(true);
    }
}
