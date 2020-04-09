using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //---Config params
    [SerializeField] float delayInSeconds = 2f;
    [SerializeField] float timeLeft = 30f;
    //---Used to delay the UI label showing up
    [SerializeField] float waitToLoad = 2f;

    [Header("Set UI for win/lose")]
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    int currentSceneIndex;
    int currentSceneIndexFixed;
    bool levelTimerFinished = false;

    //---use it to display the countdown timer for level
    public Text timerLeftText;
    //---to display the level number
    public Text levelNumberText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //---get the current scene index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //---WIP, should be a better way to get the scene Index without
        //---considering the Main Screen
        currentSceneIndexFixed = currentSceneIndex - 1;
        levelNumberText.text = currentSceneIndexFixed.ToString();
        //---set the win/lose GUI hidden until it happens
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeftInLevel();
    }

    //---Activate the lose label and shows the red screen
    public void showGameOver()
    {
        Time.timeScale = 0;
        loseLabel.SetActive(true);

    }

    public void LevelTimeFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
        //---Show the Victory Message WIP and go to next level
        winLabel.SetActive(true);
        //---stops any movement and then continue to the next level
        Time.timeScale = 0;
        //StartCoroutine(WaitForTime());
        //LoadNextScene();
        FindObjectOfType<LevelLoader>().LoadNextScene();
        
    }


    

    private void StopSpawners()
    {
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }


    public void TimeLeftInLevel()
    {
        //---Timer countdown for the game
        timeLeft -= Time.deltaTime;
        //---display it in the UI
        timerLeftText.text = (timeLeft).ToString("0");
        if (timeLeft <= 0)
        {
            Debug.Log("Next Level");
            LevelTimeFinished();
        }
    }
}
