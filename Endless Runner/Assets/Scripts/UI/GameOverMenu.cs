using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverMenuUI;

  

    public static GameOverMenu instance;
    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //changed PlayerGravity.gravity to defualt 1
        PlayerGravity.gravity = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        // i didn't knew was this the right way but I did this for now if you want.
        PlayerGravity.gravity = 1;
        PlayerReference.player.GetComponent<Rigidbody2D>().gravityScale = 1;
        SceneManager.LoadScene("Endless Runner");
    }
}
