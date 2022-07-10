using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonNewGame;
    public string sceneNewGame;
    public string sceneLevelSelect;
    public string sceneMainMenu;
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayNewGame()
    {
        SceneManager.LoadScene(sceneNewGame);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(sceneLevelSelect);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(sceneMainMenu);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ButtonStartSelected()
    {
        buttonStart.Select();
    }
    public void ButtonNewGameSelected()
    {
        buttonNewGame.Select();
    }
}
