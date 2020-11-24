using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        if (!gameIsPaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
        else
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        if (gameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        PlayerReference.player.GetComponent<Rigidbody2D>().gravityScale = 1;
        SceneManager.LoadScene("Endless Runner");
    }
}
