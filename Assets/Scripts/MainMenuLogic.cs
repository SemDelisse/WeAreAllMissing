using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
        private GameObject mainMenu;
    private GameObject optionsMenu;
    private GameObject CreditsMenu;

    //public AudioSource buttonSound;



    void Start()
    {
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = GameObject.Find("OptionsMenu");
        CreditsMenu = GameObject.Find("CreditsMenu");

        mainMenu.GetComponent<Canvas>().enabled = true;
        optionsMenu.GetComponent<Canvas>().enabled = false;
        CreditsMenu.GetComponent<Canvas>().enabled = false;
    }

    public void StartButton()
    {
        mainMenu.GetComponent<Canvas>().enabled = false;
        //buttonSound.Play();
        SceneManager.LoadScene("Level0");
    }

    public void OptionsButton()
    {
        Debug.Log("It works fix the problem");
        //buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        optionsMenu.GetComponent<Canvas>().enabled = true;
        
    }

    public void CreditsButton()
    {
        Debug.Log("It works fix the problem");
        //buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        CreditsMenu.GetComponent<Canvas>().enabled = true;
        
    }

    public void ExitGameButton()
    {
        //buttonSound.Play();
        Application.Quit();
    }

    public void ReturnToMainMenuButton()
    {
        Debug.Log("It works fix the problem");
        //buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = true;
        optionsMenu.GetComponent<Canvas>().enabled = false;
        CreditsMenu.GetComponent<Canvas>().enabled = false;
        
    }



    void Update()
    {

    }
}
