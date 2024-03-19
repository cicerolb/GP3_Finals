using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3DialogueManager : MonoBehaviour
{
    // Player
    [SerializeField] private GameObject player;

    // Enemy
    [SerializeField] GameObject enemy;

    // Dialogues
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject dialogue3;
    [SerializeField] private GameObject dialogue4;

    // Objectives
    [SerializeField] private GameObject objective1;
    [SerializeField] private GameObject objective2;

    // Other Scripts
    [SerializeField] private ObjectiveSkip objectiveSkip;
    [SerializeField] private AreaCollider restaurantCollider, schoolExitCollider;
    [SerializeField] private AudioManager audioManager;

    // Limiters
    [SerializeField] private bool hasRun1 = false;
    [SerializeField] private bool hasRun2 = false;
    [SerializeField] private bool hasRun3 = false;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("SceneAudioManager").GetComponent<AudioManager>();
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

    private void Dialogue1()
    {
        objective1.SetActive(true);
        dialogue1.SetActive(true);
    }

    void Dialogue2Proc()
    {
        schoolExitCollider = GameObject.Find("SchoolExit").GetComponent<AreaCollider>();

        if (!hasRun1)
        {
            if (schoolExitCollider.dialogueStart)
            {
                audioManager.chase = true;
                dialogue2.SetActive(true);
                enemy.SetActive(true);
                hasRun1 = true;
            }
        }
    }

    void Dialogue3Proc()
    {
        restaurantCollider = GameObject.Find("Restaurant").GetComponent<AreaCollider>();

        if (!hasRun2)
        {
            if (restaurantCollider.dialogueStart)
            {
                audioManager.chaseStop = true;
                enemy.SetActive(false);
                dialogue3.SetActive(true);
                hasRun2 = true;
            }
        }
        
    }
}
