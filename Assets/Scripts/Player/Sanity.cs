using TMPro;
using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI sanity;
    public float startNumber = 100f;       
    public float countSeconds = 10f;      

    private float timeMultiplier = 50f;    

    void Start()
    {
        timeMultiplier = startNumber / countSeconds;  
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (startNumber > 0)
        {
            startNumber -= Time.deltaTime * timeMultiplier;
            sanity.SetText(((int)startNumber).ToString()); 
            yield return new WaitForSeconds(1f); 
        }
    }
}
