using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private string scene;
    [SerializeField] GameObject startPage;
    [SerializeField] GameObject creditsPage;
    [SerializeField] GameObject instructionsPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            StartButtonPressed();
        }
    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene(scene);
    }

    public void CreditsButton(){
        startPage.SetActive(false);
        creditsPage.SetActive(true);
    }

    public void BackButton(){
        startPage.SetActive(true);
        creditsPage.SetActive(false);
        instructionsPage.SetActive(false);
    }

    public void InstructionsButton(){
        startPage.SetActive(false);
        instructionsPage.SetActive(true);
    }
    
}
