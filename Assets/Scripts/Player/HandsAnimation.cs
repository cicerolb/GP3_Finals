using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public bool isFlashlightOn = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFlashlightOn = !isFlashlightOn;

            animator.SetBool("IsFlashlightOn", isFlashlightOn);
        }
    }
}
