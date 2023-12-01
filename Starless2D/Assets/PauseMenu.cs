using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    //public GameObject optionsMenuUI;
    public static bool GameIsPaused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            /*if (GameIsPaused && optionsMenuUI.activeSelf) {
                pauseMenuUI.SetActive(true);
                optionsMenuUI.SetActive(false);
            } else */if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }  

    public void LoadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
