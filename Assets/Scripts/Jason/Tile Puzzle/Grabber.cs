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
