using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;

    public GameObject titleScreen;

    public Button restartButton;

    public HealthBar healthBar;

    public bool isGameActive;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        scoreText.text = ("Score: " + Score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.gameObject.GetComponent<PlayerController>().enabled = false;
        player.dirtParticle.Stop();

        scoreText.gameObject.SetActive(false);
        FinalScore();
        titleScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame()
    {
        isGameActive = true;
        Score = 0;
        titleScreen.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void FinalScore()
    {
        finalScoreText.text = Score.ToString();
        finalScoreText.text = ("Your Score: " + Score);
    }
}
