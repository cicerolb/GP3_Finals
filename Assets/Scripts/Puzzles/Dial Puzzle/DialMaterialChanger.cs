using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialMaterialChanger : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;

    public bool red, blue;
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];

       if (blue)
        {
            x = 1;
        }
       else
        {
            x = 0;
        }
    }

    public void MaterialChanger()
    {
        blue = !blue;
    }
}
