using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SewerScript : MonoBehaviour
{
    // Game Objects
    private GameObject player;
    [SerializeField] GameObject dialPuzzleCamera;

    [SerializeField] private GameObject cooldownBar;
    

    // Other Scripts
    [SerializeField] AudioManager audioManager;
    [SerializeField] CooldownScript cooldownScript;



    // Canvas Game Objects
    [SerializeField] private GameObject hideScreen;

    // Booleans
    public bool sewerHide = false;
    public bool enterSewerStart = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = GameObject.Find("SceneAudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sewerHide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitSewer();
            }
        }

        if (enterSewerStart)
        {
            EnterSewer();
            enterSewerStart = false;
        }

    }

    public void EnterSewer()
    {
        sewerHide = true;
        audioManager.sewer = true;
        hideScreen.SetActive(true);
        player.SetActive(false);
        dialPuzzleCamera.SetActive(false);
    }

    private void ExitSewer()
    {
        sewerHide = false;
        audioManager.sewer = false;
        hideScreen.SetActive(false);
        player.SetActive(true);
        dialPuzzleCamera.SetActive(true);
    }
}
