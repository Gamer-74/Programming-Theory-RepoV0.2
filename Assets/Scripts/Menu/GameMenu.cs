using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Button startGame;
    public Button quitGame;
    public Button leaderBoard;
    public Button backMenu;

    public GameObject titleMenu;
    public GameObject leadersBoard;

    public TextMeshProUGUI gameName;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaderBoard()
    {
        titleMenu.gameObject.SetActive(false);
        leadersBoard.gameObject.SetActive(true);   
    }

    public void BackMenu()
    {
        leadersBoard.gameObject.SetActive(false);
        titleMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
