using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameScoreManager : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI score;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        userName.text = PlayerPrefs.GetString("UsersCount");
    }

    void AppearText()
    {
        
        if(gameManager)
        {
            gameManager.isGameActive = true;
            userName.text = PlayerPrefs.GetString("UsersCount");
        }
    }

    public void SaveNameScore(string name, int Score)
    {
        if(gameManager.isGameActive == false)
        {
            userName.text = PlayerPrefs.GetString("UsersCount");
            score.text = Score.ToString();
        }
    }
}
