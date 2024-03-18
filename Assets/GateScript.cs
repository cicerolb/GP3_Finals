using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] DialPuzzleManager1 dialPuzzleManager1;
    [SerializeField] AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        dialPuzzleManager1 = GameObject.Find("DialPuzzle").GetComponent<DialPuzzleManager1>();
        audioManager = GameObject.Find("SceneAudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialPuzzleManager1.puzzleComplete)
        {
            audioManager.stoneGate = true;
            gameObject.SetActive(false);
        }
    }
}
