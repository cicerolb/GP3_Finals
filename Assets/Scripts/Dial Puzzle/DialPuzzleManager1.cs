using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialPuzzleManager1 : MonoBehaviour
{


    [SerializeField] private Vector3[] dial;
    [SerializeField] private Transform arrow;
    [SerializeField] private TextMeshProUGUI debug;
    int i = 0;
    int dialInput = 1;
    private int rotationsRemaining = 0;


    public float cooldownTime;
    private float lastActionTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CoolDown());


        if (cooldownTime == 0)
        {
            RotateArrow();
            lastActionTime = Time.time;

        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rotationsRemaining = 3;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            rotationsRemaining = 4;
        }

        Debug.Log(cooldownTime);







        debug.SetText("rotations remaining: " + rotationsRemaining + "  i: " + i);
    }

    void RotateArrow()
    {
        if (i >= dial.Length)
        {
            i = 0;
        }

        if (rotationsRemaining > 0)
        {
            arrow.eulerAngles = dial[i];

            i = (i + 1) % dial.Length;
            cooldownTime -= 1;






            rotationsRemaining--;


        }

    }

    IEnumerator CoolDown()
    {
        cooldownTime -= 1;
        yield return new WaitForSeconds(0.5f);

            

    }
}
