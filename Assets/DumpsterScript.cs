using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterScript : MonoBehaviour
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
    public bool dumpsterHide = false;
    public bool enterDumpsterStart = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = GameObject.Find("SceneAudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dumpsterHide)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitDumpster();
            }
        }

        if (enterDumpsterStart)
        {
            EnterDumpster();
            enterDumpsterStart = false;
        }

    }

    public void EnterDumpster()
    {
        dumpsterHide = true;
        audioManager.dumpster = true;
        hideScreen.SetActive(true);
        player.SetActive(false);
        if (dialPuzzleCamera != null)
        {
            dialPuzzleCamera.SetActive(false);
        }
    }

    private void ExitDumpster()
    {
        dumpsterHide = false;
        audioManager.dumpster = false;
        hideScreen.SetActive(false);
        player.SetActive(true);
        if (dialPuzzleCamera != null)
        {
            dialPuzzleCamera.SetActive(true);
        }
    }
}
