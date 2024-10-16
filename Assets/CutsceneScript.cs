using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] GameObject trafficSounds;
    [SerializeField] GameObject condoSounds;
    [SerializeField] GameObject enemy, exit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundEffects());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SoundEffects()
    {
        trafficSounds.SetActive(true);
        yield return new WaitForSeconds(4.15f);
        trafficSounds.SetActive(false);
        yield return new WaitForSeconds(2.75f);
        condoSounds.SetActive(true);
        yield return new WaitForSeconds(10.5f);
        condoSounds.SetActive(false);
        yield return new WaitForSeconds(2f);
        enemy.SetActive(true);
        yield return new WaitForSeconds(1f);
        exit.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }


    public void ExitButton()
    {
        Application.Quit();
    }
}
