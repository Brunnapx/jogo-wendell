using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public player Jogador;
    public Text healthText;

    public int score;
    public Text scoreText;

    public GameObject pauseObj;
    public GameObject gameOverObj;
    

    public int totalScore;

    private bool isPaused;

    public static GameController instance;
    
    // Aweke é inicializado antes de todos os metodos start() do seu projeto 
    void Awake()
    {
        instance = this;
        
    }
    
    void Start()
    {
        totalScore = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
     PauseGame();
    }

    public  void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        
        
        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }

    public void gameOver()
    {
        gameOverObj.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Jogador.transform.position = Jogador.respowCheck;
        Jogador.health = 3;
        UpdateLives(Jogador.health);
        cam CameraRes = Camera.main.GetComponent<cam>();
        CameraRes.transform.position = CameraRes.Respawn;

        gameOverObj.SetActive(false);
    }
    
}
