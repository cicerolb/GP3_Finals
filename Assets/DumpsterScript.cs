using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterScript : MonoBehaviour
{
    private GameObject player;
    public bool dumpsterHide = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HideInDumpster();
    }

    void HideInDumpster()
    {
        if (dumpsterHide) 
        {
            Debug.Log("TITEEE");
            dumpsterHide = false;
        }
    }
}