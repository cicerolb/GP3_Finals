using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faded : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("FadeOut", true);
        if (SceneManager.GetActiveScene().name == "Loop 1")
        {
            Debug.Log("loop1");
            animator.SetBool("FadeOut", false);

        }
        

    }


}
