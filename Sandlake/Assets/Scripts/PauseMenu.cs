using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    AudioManager audioManager;

    // Update is called once per frame
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        Restart();
    }
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

        FindObjectOfType<AudioManager>().Play("Ambiente");
        GameIsPaused = false;
    }

    void Pause ()
    {
        FindObjectOfType<AudioManager>().Pause("Ambiente");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu ()
    {
        Destroy(GameObject.Find("AudioManager"));
        SceneManager.LoadScene("Start Game");
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
