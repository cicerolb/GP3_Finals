using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Grabber : MonoBehaviour
{
    public AudioSource audioSource;
    PlayerMovement playerMovement;
    [SerializeField] LoopManager loopManager;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3[] dial;
    [SerializeField] private GameObject[] dialMaterials;
    [SerializeField] private Transform arrow;
    [SerializeField] private TextMeshProUGUI debug;
    int i = 0;
    int x = 0;
    private int rotationsRemaining = 0;

    bool dial0, dial1, dial2, dial3, dial4, dial5, dial6;

    public float cooldownTime = 5;
    public int desiredOutput;
    bool materialChanged = true;
    bool puzzleStart = false;


    float dist;
    CinemachineVirtualCamera playerCamera;
    CinemachineVirtualCamera slidingPuzzleCamera;

    public GameObject dialChoices;

    // Start is called before the first frame update

    void Start()
    {
        loopManager = GameObject.FindGameObjectWithTag("Exit").GetComponent<LoopManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
        slidingPuzzleCamera = GameObject.Find("SlidingPuzzleCamera").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        StartDialPuzzle();

        if (puzzleStart)
        {
            playerMovement.canMove = false;

            Cursor.lockState = CursorLockMode.Confined;

            slidingPuzzleCamera.Priority = 11;

            if (Input.GetKeyDown(KeyCode.F))
            {
                puzzleStart = false;
            }

        }

        if (!puzzleStart)
        {
            slidingPuzzleCamera.Priority = 9;
            Cursor.lockState = CursorLockMode.Locked;
            playerMovement.canMove = true;
        }

        Debug.Log(dist);
    }

    void StartDialPuzzle()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                puzzleStart = true;

                Debug.Log("asdasda");
            }
        }
    }


}
