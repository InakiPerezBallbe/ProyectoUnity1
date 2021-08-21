using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject interfaz;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                interfaz.SetActive(true);
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(false);
                Time.timeScale = 1;
                gamePaused = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                interfaz.SetActive(false);
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                gamePaused = true; 
            }
        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        interfaz.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
