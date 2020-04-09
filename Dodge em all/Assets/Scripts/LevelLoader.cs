using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    [SerializeField] float waitToLoad = 2f;
    [SerializeField] float delayInSeconds = 2f;

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //---if there is the splash screen
        //if (currentSceneIndex == 0)
        //{
        //    StartCoroutine(WaitForTime());
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadStartMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        //---resetting Game, using GameSession.cs class and method ResetGame
        FindObjectOfType<GameSession>().ResetGame();
    }

    //---start the game
    public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
        //---resetting the game, the scores and all stuff
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadControlsScene()
    {
        SceneManager.LoadScene("How to Play");
    }


    //---Loads the next scene after finishing the level
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void RestartScene()
    {
        //---after losing and stopped everything, set back to 1
        Time.timeScale = 1;
        //---After lose screen, restart
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //---This works when presenting the game over screen
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        Time.timeScale = 0;
        //loseLabel.SetActive(true);
        SceneManager.LoadScene("Game Over");
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    




}
