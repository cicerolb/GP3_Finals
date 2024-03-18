using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Audio Sources and Game Objects
    [SerializeField] AudioSource footSteps;
    [SerializeField] GameObject enemyFootStepsSound;
    [SerializeField] AudioSource jumpScareSound;
    [SerializeField] AudioSource chaseSound;
    [SerializeField] GameObject mazeMusicSound;
    [SerializeField] GameObject cricketSound;
    [SerializeField] GameObject dumpsterSound;
    [SerializeField] GameObject stoneGateSound;


    // Bools
    public bool enemyFootSteps = false;
    public bool jumpScare = false;
    public bool chase = false;
    public bool chaseStop = false;
    public bool mazeMusic = false;
    public bool dumpster = false;
    public bool stoneGate = false;

    // Other Scripts
    [SerializeField] BackgroundNoise backgroundNoise;

    // Start is called before the first frame update
    void Start()
    {
        cricketSound = GameObject.Find("Crickets");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFootStepsAudio();
        JumpScareAudio();
        ChaseAudio();
        MazeMusic();
        CricketSound();
        DumpsterSound();
        StoneGateSound();
    }

    void EnemyFootStepsAudio()
    {
        if (SceneManager.GetActiveScene().name == "Loop 2")
        {
            if (enemyFootSteps)
            {
                enemyFootStepsSound.SetActive(true);
            }
            else
            {
                enemyFootStepsSound.SetActive(false);
            }
        }
        
    }


    void JumpScareAudio()
    {
        if (jumpScare)
        {
            jumpScareSound.Play();
            jumpScare = false;
        }
    }

    void ChaseAudio()
    {
        if (chase)
        {
            chaseSound.Play();
            chase = false;
        }

        if (chaseStop)
        {
            chaseSound.Stop();
        }
    }

    void MazeMusic()
    {
        if (SceneManager.GetActiveScene().name == "Loop 4")
        {
            backgroundNoise = GameObject.Find("SilentSpot").GetComponent<BackgroundNoise>();

            if (mazeMusic)
            {
                mazeMusicSound.SetActive(true);
                if (backgroundNoise.insideSchool)
                {
                    cricketSound.SetActive(false);
                }
            }
            else
            {
                mazeMusicSound.SetActive(false);
                if (!backgroundNoise.insideSchool)
                {
                    cricketSound.SetActive(true);
                }
            }
        }
        
    }

    void CricketSound()
    {
        backgroundNoise = GameObject.Find("SilentSpot").GetComponent<BackgroundNoise>();
        if (backgroundNoise.insideSchool || mazeMusic)
        {
            cricketSound.SetActive(false);
        }
        else if (!backgroundNoise.insideSchool || !mazeMusic)
        {
            cricketSound.SetActive(true);
        }
    }

    void DumpsterSound()
    {
        if (dumpster)
        {
            dumpsterSound.SetActive(true);
        }
        else
        {
            dumpsterSound.SetActive(false);
        }
    }

    void StoneGateSound()
    {
        if (stoneGate)
        {
            stoneGateSound.SetActive(true);
        }
    }

}
