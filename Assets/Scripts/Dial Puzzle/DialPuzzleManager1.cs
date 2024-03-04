using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialPuzzleManager1 : MonoBehaviour
{


    [SerializeField] private Vector3[] dial;
    [SerializeField] private GameObject[] dialMaterials;
    [SerializeField] private Transform arrow;
    [SerializeField] private TextMeshProUGUI debug;
    int i = 0;
    int x = 0;
    int dialInput = 1;
    private int rotationsRemaining = 0;

    bool dial0, dial1, dial2, dial3, dial4, dial5, dial6;

    public float cooldownTime = 5;
    public int desiredOutput;
    bool materialChanged = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PuzzleComplete();

        cooldownTime = Mathf.Clamp(cooldownTime - Time.deltaTime, 0f, Mathf.Infinity);

        ChangeColor();

        if (cooldownTime == 0)
        {
            RotateArrow();

        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (cooldownTime == 0)
            {
                rotationsRemaining = 3;
                materialChanged = false;
                desiredOutput += 3;
            }
            

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (cooldownTime == 0)
            {
                rotationsRemaining = 4;
                materialChanged = false;
                desiredOutput += 4;
            }
           
        }

        if (desiredOutput >= 7)
        {
            desiredOutput -= 7;
        }








        debug.SetText("dial0: "+ dial0+ "dial1: " + dial1 + " dial2: " + dial2 + "dial3: " + dial3 + "dial4: " +dial4+ "dial5: "+dial5+"dial6: "+dial6) ;
    }

    void RotateArrow()
    {

        if (rotationsRemaining > 0)
        {
            if (cooldownTime == 0)
            {

                x = (i + 1) % dialMaterials.Length;
                i = (i + 1) % dial.Length;
                arrow.eulerAngles = dial[i];

                rotationsRemaining--;
                cooldownTime += 0.5f;



            }

        }

    }
    void ChangeColor()
    {
        if (!materialChanged)
        {
            if (i == desiredOutput)
            {
                dialMaterials[x].GetComponent<DialMaterialChanger>().MaterialChanger();
                materialChanged = true;
            }
        }
    }

    void PuzzleComplete()
    {
        dial0 = dialMaterials[0].GetComponent<DialMaterialChanger>().blue;
        dial1 = dialMaterials[1].GetComponent<DialMaterialChanger>().blue;
        dial2 = dialMaterials[2].GetComponent<DialMaterialChanger>().blue;
        dial3 = dialMaterials[3].GetComponent<DialMaterialChanger>().blue;
        dial4 = dialMaterials[4].GetComponent<DialMaterialChanger>().blue;
        dial5 = dialMaterials[5].GetComponent<DialMaterialChanger>().blue;
        dial6 = dialMaterials[6].GetComponent<DialMaterialChanger>().blue;
        {
            if (dial0 == true && dial1 == false && dial2 == true && dial3 == true && dial4 == false && dial5 == false && dial6 == false)
            {
                Debug.Log("PUZZLE COMPLETE");
            }
        }

        
    }

}
