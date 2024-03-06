using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimation : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public bool isFlashlightOn = false;
    [SerializeField] public bool flashlightAnimation = false;
    [SerializeField] private DialPuzzleManager1 dialPuzzleManager;
    [SerializeField] private bool puzzleStart;


    void Start()
    {
        dialPuzzleManager = GameObject.FindGameObjectWithTag("Dial Puzzle").GetComponent<DialPuzzleManager1>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("IsFlashlightOn", flashlightAnimation);
        if (dialPuzzleManager.dialPuzzleStart)
        {
            puzzleStart = true;
        }
        else
        {
            puzzleStart = false;
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
