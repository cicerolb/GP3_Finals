using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4DialogueManager : MonoBehaviour
{
    // Player
    [SerializeField] private GameObject player;

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
    [SerializeField] private AreaCollider mazeEntranceCollider, schoolExitCollider, mazeCollider;
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
        MazeAudioStart();

    }

    private void Dialogue1()
    {
        objective1.SetActive(true);
        dialogue1.SetActive(true);
    }

    void Dialogue2Proc()
    {
        mazeEntranceCollider = GameObject.Find("MazeEntrance").GetComponent<AreaCollider>();

        if (!hasRun2)
        {
            if (mazeEntranceCollider.dialogueStart)
            {
                audioManager.chaseStop = true;
                dialogue2.SetActive(true);
                hasRun2 = true;
            }
        }
    }

    void MazeAudioStart()
    {
        mazeCollider = GameObject.Find("MazeCollider").GetComponent<AreaCollider>();

        if (mazeCollider.dialogueStart)
        {
            audioManager.mazeMusic = true;
        }
        else
        {
            audioManager.mazeMusic = false;
        }
    }

    void Dialogue3Proc()
    {


    }
}
