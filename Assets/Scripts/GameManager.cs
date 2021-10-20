using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get;  set; }
    public int Score { get;  set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    public GameObject titleScreen;
    public GameObject nameScoreManager;
    public GameObject backGroundMusic;
    public Button restartButton;
    public Button mainMenu;
    public HealthBar healthBar;
    public bool isGameActive;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        UpdateScore(name, 0);
    }

    public void UpdateScore(string name, int ScoreToAdd)
    {
        Score += ScoreToAdd;
        name = PlayerPrefs.GetString("UsersCount");
        scoreText.text = $" {name} {Score}";
    }

    public void UpdateHealth()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        if(gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
            player.ChangeHealth(-1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.gameObject.GetComponent<PlayerController>().enabled = false;

        scoreText.gameObject.SetActive(false);
        FinalScore();
        titleScreen.gameObject.SetActive(true);
        player.dirtParticle.Stop();
        isGameActive = false;
        backGroundMusic.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        isGameActive = true;
        Score = 0;
        titleScreen.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        if(Score > PlayerPrefs.GetInt("FinalScores"))
        {
            PlayerPrefs.SetString("FinalScores", finalScoreText.text);
        }
        SceneManager.LoadScene(0);
    }

    public void FinalScore()
    {
        finalScoreText.text = Score.ToString();
        name = PlayerPrefs.GetString("UsersCount");
        finalScoreText.text = $" {name} {Score}";
    }

    public string SaveFinalScore(string theFinal)
    {
        PlayerPrefs.SetString("theFinal", finalScoreText.text);
        theFinal = finalScoreText.text;
        return theFinal;
    }
}
