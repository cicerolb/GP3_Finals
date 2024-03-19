using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTransform : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            player = GameObject.Find("Player");
            if (player != null)
            {
                gameObject.transform.position = player.transform.position;
                gameObject.transform.rotation = player.transform.rotation;

            }
        }
    }
}