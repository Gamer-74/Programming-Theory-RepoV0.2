using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameMenu : MonoBehaviour
{
    public Button startGame;
    public Button leaderBoard; 
    public Button quitGame;
    public Button backbutton;

    public GameObject titleMenu;
    public GameObject leadersBoard;

    public TextMeshProUGUI gameName;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaderBoard()
    {
        leadersBoard.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
    }

    public void BackButton()
    {
        leadersBoard.gameObject.SetActive(false);
        titleMenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit;
#endif
    }
}
