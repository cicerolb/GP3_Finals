using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    [SerializeField] private GameObject currentPuzzle;
    [SerializeField] public bool dialPuzzle = false;
    [SerializeField] public bool prologuePuzzle = false;


    // Start is called before the first frame update
    void Start()
    {
        currentPuzzle = GameObject.FindGameObjectWithTag("Puzzle");

        if (currentPuzzle.name == "DialPuzzle")
        {
            dialPuzzle = true;

        }
        else if (currentPuzzle.name == "ProloguePuzzle")
        {
            prologuePuzzle = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
