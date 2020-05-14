using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Restart();
            } else
            {
                Pause();
            }
        }
        
    }

    public void Restart ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene("Start Game");
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
