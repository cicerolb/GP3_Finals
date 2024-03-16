using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource footSteps;
    [SerializeField] AudioSource enemyFootStepsSound;
    public bool enemyFootSteps = false;
    [SerializeField] AudioSource jumpScareSound;
    public bool jumpScare = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyFootSteps)
        {
            enemyFootStepsSound.Play();
            enemyFootSteps = false;
        }

        if (jumpScare)
        {
            jumpScareSound.Play();
            jumpScare = false;
        }
    }
}
