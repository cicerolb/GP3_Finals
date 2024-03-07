using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimation : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public bool isFlashlightOn = false;
    [SerializeField] public bool flashlightAnimation = false;
    [SerializeField] private DialPuzzleManager1 dialPuzzleManager;
    [SerializeField] private ProloguePuzzleManager prologuePuzzleManager;
    [SerializeField] private bool puzzleStart;
    [SerializeField] private GameObject currentPuzzle;


    void Start()
    {
        animator = GetComponent<Animator>();

        currentPuzzle = GameObject.FindGameObjectWithTag("Puzzle");

        if (currentPuzzle.name == "DialPuzzle")
        {
            dialPuzzleManager = GameObject.FindGameObjectWithTag("Puzzle").GetComponent<DialPuzzleManager1>();

        }
        else if (currentPuzzle.name == "ProloguePuzzle")
        {
            prologuePuzzleManager = GameObject.FindGameObjectWithTag("Puzzle").GetComponent<ProloguePuzzleManager>();
        }
    }

    void Update()
    {
        animator.SetBool("IsFlashlightOn", flashlightAnimation);
        if (dialPuzzleManager != null)
        {
            if (dialPuzzleManager.dialPuzzleStart)
            {
                puzzleStart = true;
            }
            else
            {
                puzzleStart = false;
            }
        }
        else if (prologuePuzzleManager != null)
        {
            if (prologuePuzzleManager.prologuePuzzleStart)
            {
                puzzleStart = true;
            }
            else
            {
                puzzleStart = false;
            }
        }





        if (!puzzleStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (flashlightAnimation)
                {
                    flashlightAnimation = !flashlightAnimation;
                    //animator.SetBool("IsFlashlightOn", flashlightAnimation);
                    StartCoroutine(ToggleFlashlight(0));
                }
                else
                {
                    flashlightAnimation = !flashlightAnimation;
                    //animator.SetBool("IsFlashlightOn", flashlightAnimation);
                    StartCoroutine(ToggleFlashlight(0.7f));
                }
                
            }
        }

        

    }

    IEnumerator ToggleFlashlight(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isFlashlightOn = !isFlashlightOn;
    }
}
