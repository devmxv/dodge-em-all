using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;

    //---From UI
    //[SerializeField] Text scoreText;
    

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        //---checks if there is another game session in the level
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        print(numberGameSessions);
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        print("Score: " + score);
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        print("Score added: " + score);
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
