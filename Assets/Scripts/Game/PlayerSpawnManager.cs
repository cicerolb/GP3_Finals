using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawn;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = GameObject.FindGameObjectWithTag("Spawn");
    }

    // Start is called before the first frame update
    void Start()
    {

        player.SetActive(false);
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
