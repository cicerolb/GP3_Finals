using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsOnLightsOff : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private bool lightOn;
    [SerializeField] HandsAnimation handAnimation;

    private void Awake()
    {
        handAnimation = GameObject.Find("flashlight").GetComponent<HandsAnimation>();
    }
    public void Update()
    {

        if (!handAnimation.isFlashlightOn)
        {
            lightOn = false;
        }

        else
        {
            lightOn = true;
        }

        //lightOn = !lightOn;


        if (lightOn)
        {
            light.SetActive(true);

        }
        else
        {
            light.SetActive(false);

        }


    }
}
