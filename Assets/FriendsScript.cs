using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendsScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float dist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (dist <= 10)
        {
            gameObject.transform.rotation = player.transform.rotation;

        }
    }
}
