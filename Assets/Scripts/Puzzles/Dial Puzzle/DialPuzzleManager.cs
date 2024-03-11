using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;




public class DialPuzzleManager : MonoBehaviour
{
    [SerializeField] private Vector3 dial_1_rotation;
    [SerializeField] private Vector3 dial_2_rotation;
    [SerializeField] private Vector3 dial_3_rotation;
    [SerializeField] private Vector3 dial_4_rotation;
    [SerializeField] private Vector3 dial_5_rotation;
    [SerializeField] private Vector3 dial_6_rotation;
    [SerializeField] private Vector3 dial_7_rotation;

    [SerializeField] private GameObject dial_1;
    [SerializeField] private GameObject dial_2;
    [SerializeField] private GameObject dial_3;
    [SerializeField] private GameObject dial_4;
    [SerializeField] private GameObject dial_5;
    [SerializeField] private GameObject dial_6;
    [SerializeField] private GameObject dial_7;


    [SerializeField] private GameObject arrow;

    [SerializeField] private float speed = 0.5f;

    private int dialInput;

    bool materialChanged = true;


    public bool blue1, blue2, blue3;

    public GameObject jumpscare;
    // Start is called before the first frame update
    void Start()
    {
        dialInput = 1;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(dialInput);

        DialRotation();

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            dialInput += 3;
            Debug.Log("Dial Input: " + dialInput);
            materialChanged = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            dialInput += 4;
            Debug.Log("Dial Input: " + dialInput);
            materialChanged = false;
        }



        if (dialInput > 7)
        {
            dialInput -= 7;
        }

        if (blue1 == true && blue2 == true && blue3 == true)
        {
            jumpscare.SetActive(true);
        }





    }

    void DialRotation()
    {

        switch (dialInput)
        {
            case 1:
                arrow.transform.eulerAngles = dial_1_rotation;
                break;
            case 2:
                arrow.transform.eulerAngles = dial_2_rotation;
                break;
            case 3:
                arrow.transform.eulerAngles = dial_3_rotation;
                break;
            case 4:
                arrow.transform.eulerAngles = dial_4_rotation;
                break;
            case 5:
                arrow.transform.eulerAngles = dial_5_rotation;
                break;
            case 6:
                arrow.transform.eulerAngles = dial_6_rotation;
                break;
            case 7:
                arrow.transform.eulerAngles = dial_7_rotation;
                break;


        }


        if (!materialChanged)
        {
            switch (dialInput)
            {
                case 1:
                    dial_1.GetComponent<DialMaterialChanger>().MaterialChanger();
                    blue1 = !blue1;
                    break;
                case 2:
                    dial_2.GetComponent<DialMaterialChanger>().MaterialChanger();
                    break;
                case 3:
                    dial_3.GetComponent<DialMaterialChanger>().MaterialChanger();
                    blue2 = !blue2;
                    break;
                case 4:
                    dial_4.GetComponent<DialMaterialChanger>().MaterialChanger();
                    blue3 = !blue3;
                    break;
                case 5:
                    dial_5.GetComponent<DialMaterialChanger>().MaterialChanger();
                    break;
                case 6:
                    dial_6.GetComponent<DialMaterialChanger>().MaterialChanger();
                    break;
                case 7:
                    dial_7.GetComponent<DialMaterialChanger>().MaterialChanger();
                    break;


            }
            materialChanged = true;
        }
       
        




    }


}
