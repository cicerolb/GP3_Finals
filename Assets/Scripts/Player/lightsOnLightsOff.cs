using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsOnLightsOff : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private bool lightOn;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!lightOn) 
            {
                light.SetActive(false);
            }

            else
            {
                light.SetActive(true);
            }

            lightOn = !lightOn;
        }
    }
}
