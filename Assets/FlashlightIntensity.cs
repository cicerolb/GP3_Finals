using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightIntensity : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] float[] lightPower;
    [SerializeField] int i;
    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            i = (i + 1) % lightPower.Length;
        }






        light.intensity = lightPower[i];
    }
}
