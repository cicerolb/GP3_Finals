using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTransform : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            player = GameObject.Find("Player");
            if (player != null)
            {
                gameObject.transform.position = player.transform.position;

            }
        }
    }
}