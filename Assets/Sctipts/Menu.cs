using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject tutorialMenu;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            tutorialMenu.SetActive(true);
        }
        if (gameOverScreen.activeSelf == true || tutorialMenu.activeSelf == true || winScreen.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void closeTutorial()
    {
        tutorialMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
