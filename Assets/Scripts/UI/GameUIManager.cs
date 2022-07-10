using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject pauseUIMenu;
    public static bool gameIsPaused = false;
    public string sceneMainMenuGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        gameIsPaused = false;

        pauseUIMenu.SetActive(gameIsPaused);

        Time.timeScale = 1f;
    }
    void Pause()
    {
        gameIsPaused = true;

        pauseUIMenu.SetActive(gameIsPaused);

        Time.timeScale = 0f;
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneMainMenuGame);
    }

}
