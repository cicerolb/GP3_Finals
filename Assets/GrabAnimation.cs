using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAnimation : MonoBehaviour
{
    [SerializeField] private Animator grabAnimation;
    // Start is called before the first frame update
    void Start()
    {
        grabAnimation = GetComponent<Animator>();
        grabAnimation.SetTrigger("isGrabbing");
        StartCoroutine(ResetAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(1);
        grabAnimation.SetTrigger("isGrabbing");
        gameObject.SetActive(false);
    }
}
