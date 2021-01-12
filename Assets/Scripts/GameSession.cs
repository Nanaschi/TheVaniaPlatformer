using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;
    [SerializeField] int amountOfLives = 3;
    [SerializeField] int amountPoints = 0;
    private void Awake()
    {
        var numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        healthText.text = amountOfLives.ToString();
        scoreText.text = amountPoints.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (amountOfLives > 1)
        {
            TakeLife();
            

        } else
        {
            ResetGameSession();
        }
    }

    public void AddToScore (int scoreToAdd)
    {
        amountPoints += scoreToAdd;
        scoreText.text = amountPoints.ToString();
    }

    private void TakeLife()
    {
        amountOfLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        healthText.text = amountOfLives.ToString();
    }

    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
