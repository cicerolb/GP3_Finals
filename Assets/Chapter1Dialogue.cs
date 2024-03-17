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
    [SerializeField] private AreaCollider schoolExitCollider;

    [SerializeField] private GameObject friends;
    [SerializeField] private GameObject bowl;

    [SerializeField] private float friendDist;
    [SerializeField] private float bowlDist;
    [SerializeField] private GameObject player;


    // Limiters
    [SerializeField] private bool hasRun1 = false;
    [SerializeField] private bool hasRun2 = false;
    [SerializeField] private bool hasRun3 = false;
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
        Dialogue4Proc();
    }

    void Dialogue2Proc()
    {
        schoolExitCollider = GameObject.Find("SchoolExit").GetComponent<AreaCollider>();
        if (!hasRun1)
        {
            if (schoolExitCollider.dialogueStart)
            {
                dialogue2.SetActive(true);
                hasRun1 = true;
            }
        }
      

    }

    void Dialogue3Proc()
    {

        friendDist = Vector3.Distance(player.transform.position, friends.transform.position);
        if (!hasRun2)
        {
            if (friendDist < 7)
            {
                objectiveSkip.nextObjective = true;
                dialogue3.SetActive(true);
                hasRun2 = true;
                objective2.SetActive(true);

            }


        }

    }
    public void Dialogue4Proc()
    {
        bowlDist = Vector3.Distance(player.transform.position, bowl.transform.position);

        if (!hasRun3)
        {
            if (bowlDist < 7)
            {
                dialogue4.SetActive(true);
                hasRun3 = true;
            }
        }
    }

    void Dialogue1()
    {
        objective1.SetActive(true);
        dialogue1.SetActive(true);
    }
}
