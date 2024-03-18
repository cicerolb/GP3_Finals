using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterScript : MonoBehaviour
{
    // Game Objects
    private GameObject player;
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
                //enterDumpsterStart = false;
                //cooldownScript.cooldownDone = false;
            }
        }

        if (enterDumpsterStart)
        {
            cooldownBar.SetActive(true);
            cooldownScript = cooldownBar.GetComponent<CooldownScript>();

            if (cooldownScript.cooldownDone) 
            {
                enterDumpsterStart = false;
                EnterDumpster();
            }



        }

    }

    public void EnterDumpster()
    {
        dumpsterHide = true;
        audioManager.dumpster = true;
        hideScreen.SetActive(true);
        player.SetActive(false);
    }

    private void ExitDumpster()
    {
        dumpsterHide = false;
        audioManager.dumpster = false;
        hideScreen.SetActive(false);
        player.SetActive(true);
    }
}
