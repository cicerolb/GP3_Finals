using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMateriaChanger : MonoBehaviour
{
    [SerializeField] Material[] material;
    [SerializeField] private int x;
    [SerializeField] Renderer rend;
    [SerializeField] private bool red, blue;
    private LoopManager loopManager;
    // Start is called before the first frame update
    void Start()
    {
        loopManager = GameObject.FindGameObjectWithTag("Exit").GetComponent<LoopManager>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        if (blue)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if (loopManager.puzzleComplete)
        {
            blue = true;
        }
        else
        {
            blue = false;
        }
    }
}
