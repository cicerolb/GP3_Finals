using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class ProloguePuzzleManager : MonoBehaviour
{
    public bool prologuePuzzleStart;
    [SerializeField] private HandsAnimation handsAnimation;
    [SerializeField] private SpriteRenderer flashlight;
    [SerializeField] private LoopManager loopManager;
    
    // Start is called before the first frame update
    void Start()
    {
        handsAnimation = GameObject.Find("flashlight").GetComponent<HandsAnimation>();
        flashlight = GameObject.Find("flashlight").GetComponent<SpriteRenderer>();
        loopManager = GameObject.FindGameObjectWithTag("Exit").GetComponent<LoopManager>();

    }

    // Update is called once per frame
    void Update()
    {
        prologuePuzzleStart = false;

        if (!prologuePuzzleStart )
        {
            flashlight.enabled = true;
        }
        loopManager.puzzleComplete = true;

    }
}
