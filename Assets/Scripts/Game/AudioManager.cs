using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio Sources
    [SerializeField] AudioSource footSteps;
    [SerializeField] AudioSource enemyFootStepsSound;
    [SerializeField] AudioSource jumpScareSound;
    [SerializeField] AudioSource chaseSound;

    // Bools
    public bool enemyFootSteps = false;
    public bool jumpScare = false;
    public bool chase = false;
    public bool chaseStop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFootStepsAudio();
        JumpScareAudio();
        ChaseAudio();
    }

    void EnemyFootStepsAudio()
    {
        if (enemyFootSteps)
        {
            enemyFootStepsSound.Play();
            enemyFootSteps = false;
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

}
