using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class DialPuzzleManager1 : MonoBehaviour
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
    CinemachineVirtualCamera dialPuzzleCamera;

    public GameObject dialChoices;

    // Start is called before the first frame update

    void Start()
    {
        loopManager = GameObject.FindGameObjectWithTag("Exit").GetComponent<LoopManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        playerCamera = GameObject.FindGameObjectWithTag("Player Camera").GetComponent<CinemachineVirtualCamera>();
        dialPuzzleCamera = GameObject.Find("DialPuzzleCamera").GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        StartDialPuzzle();
        DialOptions();

        if (puzzleStart)
        {
            playerMovement.canMove = false;
            playerMovement.cursorLock = false;

            dialPuzzleCamera.Priority = 11;

            if (Input.GetKeyDown(KeyCode.F))
            {
                puzzleStart = false;
            }


        }

        if (!puzzleStart)
        {
            dialPuzzleCamera.Priority = 9;
            playerMovement.canMove = true;
            playerMovement.cursorLock = true;
        }
       



        cooldownTime = Mathf.Clamp(cooldownTime - Time.deltaTime, 0f, Mathf.Infinity);

        

        if (cooldownTime == 0)
        {
            RotateArrow();

        }

        if (puzzleStart)
        {
            PuzzleComplete();
            ChangeColor();
            


            //if (Input.GetKeyDown(KeyCode.Alpha3))
            //{
            //    if (cooldownTime == 0)
            //    {
            //        rotationsRemaining = 3;
            //        materialChanged = false;
            //        desiredOutput += 3;
            //    }


            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha4))
            //{
            //    if (cooldownTime == 0)
            //    {
            //        rotationsRemaining = 4;
            //        materialChanged = false;
            //        desiredOutput += 4;
            //    }

            //}

            if (desiredOutput >= 7)
            {
                desiredOutput -= 7;
            }
        }

    }

    void RotateArrow()
    {

        if (rotationsRemaining > 0)
        {
            if (cooldownTime == 0)
            {

                x = (i + 1) % dialMaterials.Length;
                i = (i + 1) % dial.Length;
                arrow.eulerAngles = dial[i];
                
                rotationsRemaining--;
                cooldownTime += 0.5f;
                audioSource.Play();



            }

        }

    }
    void ChangeColor()
    {
        if (!materialChanged)
        {
            if (i == desiredOutput)
            {
                dialMaterials[x].GetComponent<DialMaterialChanger>().MaterialChanger();
                materialChanged = true;
            }
        }
    }

    void PuzzleComplete()
    {
        dial0 = dialMaterials[0].GetComponent<DialMaterialChanger>().blue;
        dial1 = dialMaterials[1].GetComponent<DialMaterialChanger>().blue;
        dial2 = dialMaterials[2].GetComponent<DialMaterialChanger>().blue;
        dial3 = dialMaterials[3].GetComponent<DialMaterialChanger>().blue;
        dial4 = dialMaterials[4].GetComponent<DialMaterialChanger>().blue;
        dial5 = dialMaterials[5].GetComponent<DialMaterialChanger>().blue;
        dial6 = dialMaterials[6].GetComponent<DialMaterialChanger>().blue;
        {
            if (dial0 == true && dial1 == false && dial2 == true && dial3 == true && dial4 == false && dial5 == false && dial6 == false)
            {
                Debug.Log("PUZZLE COMPLETE");
                loopManager.puzzleComplete = true;
            }
        }

        
    }

    void StartDialPuzzle()
    {
        dist = Vector3.Distance(player.transform.position , transform.position);

        if (dist < 3.5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                puzzleStart = true;

            }
        }
    }

    void DialOptions()
    {
        if (puzzleStart)
        {
            dialChoices.SetActive(true);
            
        }
        else
        {
            dialChoices.SetActive(false);
        }
    }

    public void Button3Pressed()
    {
        if (cooldownTime == 0)
        {
            rotationsRemaining = 3;
            materialChanged = false;
            desiredOutput += 3;
        }
    }

    public void Button4Pressed()
    {
        if (cooldownTime == 0)
        {
            rotationsRemaining = 4;
            materialChanged = false;
            desiredOutput += 4;
        }
    }
            

}
