using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        player.SetActive(false);
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
