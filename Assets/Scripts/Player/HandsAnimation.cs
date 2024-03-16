using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandsAnimation : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public bool isFlashlightOn = false;
    [SerializeField] public bool flashlightAnimation = false;
    [SerializeField] private DialPuzzleManager1 dialPuzzleManager;
    [SerializeField] private ProloguePuzzleManager prologuePuzzleManager;
    [SerializeField] private bool puzzleStart;
    [SerializeField] private GameObject currentPuzzle;
    [SerializeField] private PuzzleChecker puzzleChecker;


    void Start()
    {
        puzzleChecker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<PuzzleChecker>();
        animator = GetComponent<Animator>();

        currentPuzzle = GameObject.FindGameObjectWithTag("Puzzle");

        if (puzzleChecker.dialPuzzle)
        {
            dialPuzzleManager = GameObject.FindGameObjectWithTag("Puzzle").GetComponent<DialPuzzleManager1>();

        }
        else if (puzzleChecker.prologuePuzzle)
        {
            prologuePuzzleManager = GameObject.FindGameObjectWithTag("Puzzle").GetComponent<ProloguePuzzleManager>();
        }

        if (SceneManager.GetActiveScene().name == "Loop 2")
        {
            flashlightAnimation = true;
            isFlashlightOn = true;
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
            if (Input.GetKeyDown(KeyCode.F))
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
        if (!puzzleStart)
        {
            yield return new WaitForSeconds(seconds);
            isFlashlightOn = !isFlashlightOn;
        }
        

    }
}
