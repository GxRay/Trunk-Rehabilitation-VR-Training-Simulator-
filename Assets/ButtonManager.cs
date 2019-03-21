using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private void Start()
    {
        // Find Audiomanager object in project and set name
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }

    // Menu Room Buttons
    public void PlayButton ()
    {

        SceneManager.LoadScene("Dungeon Level");
        SceneManager.UnloadScene("HelloVR");

    }

    public void TrainingButton()
    {

        SceneManager.LoadScene("Training Room");
        SceneManager.UnloadScene("HelloVR");

    }
    public void TrainingBackButton()
    {

        SceneManager.UnloadScene("Training Room");
        SceneManager.LoadScene("HelloVR");

    }

    public void QuitButton ()
    {
        Application.Quit();

    }

    // Dungeon Room Buttons

    public void BackButton()
    {
        SceneManager.UnloadScene("Dungeon Level");
        SceneManager.LoadScene("HelloVR");
    }

}
