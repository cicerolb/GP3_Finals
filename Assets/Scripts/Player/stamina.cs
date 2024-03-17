using Cinemachine.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    // Other Scripts
    PlayerMovement playerMovement;



    public float playerStamina;
    float maxStamina;

    public Slider staminaBar;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        maxStamina = playerStamina;
        staminaBar.maxValue = maxStamina;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DecreaseEnergy();
        }
        else if (playerStamina > 0 && playerStamina < maxStamina)
        {
            IncreaseEnergy();
        }

        staminaBar.value = playerStamina;

        if (playerStamina <= 0)
        {
            StartCoroutine(StaminaDelay());
        }

        if (playerStamina > 0)
        {
            playerMovement.canSprint = true;
        }
        else
        {
            playerMovement.canSprint = false;
        }
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

    IEnumerator StaminaDelay()
    {
        yield return new WaitForSeconds(1f);
        IncreaseEnergy();
    }
}
