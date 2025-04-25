using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject pauseMenuUi;//экран паузы

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f; //остановка игры
        GamePause = true;
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void AgainLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }

    public void ExitLvl()
    {
        SceneManager.LoadScene(0);

    }

    
}
