using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScript : MonoBehaviour
{
    public float cooldown;
    public float maxCooldown;
    [SerializeField] Slider cooldownBar;

    public bool cooldownDone = false;
    // Start is called before the first frame update
    void Start()
    {
        cooldownBar = GetComponent<Slider>();
        cooldown = 0;
        cooldownDone = false;
        cooldownBar.maxValue = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= maxCooldown)
        {
            cooldownDone = true;
            gameObject.SetActive(false);
            cooldown = 0;
        }

        cooldownBar.value = cooldown;
    }
}
