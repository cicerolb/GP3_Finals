using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Grabber : MonoBehaviour
{
    [SerializeField] private float dist;
    [SerializeField] private GameObject player;
    [SerializeField] private bool puzzleStart = false;
    [SerializeField] CinemachineVirtualCamera tilePuzzleCamera;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tilePuzzleCamera = GameObject.Find("TilePuzzleCamera").GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        StartTilesPuzzle();

        if (puzzleStart)
        {
            tilePuzzleCamera.Priority = 11;

            if (Input.GetKeyDown(KeyCode.F))
            {
                puzzleStart = false;
            }
        }
        else
        {
            tilePuzzleCamera.Priority = 9;
        }

        
    }

    void StartTilesPuzzle()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < 3.5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                puzzleStart = true;
            }
        }
    }
}
