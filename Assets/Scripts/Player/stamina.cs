using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float playerStamina;
    float maxStamina;

    public Slider staminaBar;

    void Start()
    {
        maxStamina = playerStamina;
        staminaBar.maxValue = maxStamina;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DecreaseEnergy();
        }
        else if (playerStamina != maxStamina)
        {
            IncreaseEnergy();
        }

        staminaBar.value = playerStamina;

        Debug.Log("Player Stamina: " + playerStamina);
        Debug.Log("Slider Value: " + staminaBar.value);
    }

    private void DecreaseEnergy()
    {
        if (playerStamina != 0)
        {
            playerStamina -= 1;
        }
    }

    private void IncreaseEnergy()
    {
        playerStamina += 1;
    }
}