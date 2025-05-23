using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chapter2Dialogue : MonoBehaviour
{
    // Player
    [SerializeField] private GameObject player;
    [SerializeField] GameObject flashlight;

    // Enemy
    [SerializeField] private GameObject enemy;

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
                audioManager.enemyFootSteps = true;
                dialogue2.SetActive(true);
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
                audioManager.jumpScare = true;
                dialogue3.SetActive(true);
                hasRun2 = true;
                StartCoroutine(Jumpscare());
            }
        }
    }

    IEnumerator Jumpscare(){
        enemy.SetActive(true);
        flashlight.SetActive(false);
        yield return new WaitForSeconds (0.5f);
        enemy.SetActive(false);
        flashlight.SetActive(true);
    }
}
