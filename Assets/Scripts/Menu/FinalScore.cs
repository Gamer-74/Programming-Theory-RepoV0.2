using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalResult;
    public TextMeshProUGUI num1;
    public TextMeshProUGUI num2;
    public Button leaderBoard;
    public GameObject gameMenu;

    void Start()
    {
        finalResult.text = PlayerPrefs.GetString("FinalScores");
    }
    public void ButtonWasClicked()
    {
        if(leaderBoard)
        {
            gameMenu.SetActive(false);
            finalResult.text  = PlayerPrefs.GetString("FinalScores");
            num1.text = finalResult.text;
        }
    }
}
