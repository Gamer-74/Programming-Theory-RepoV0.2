using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    public HighScoreDisplay[] highScoreDisplayArray;

    List<HighScoreEntry> scores = new List<HighScoreEntry>();


    void Start()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));

        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].theName, scores[i].score);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }

    public void DisplayHighScore(string theName, int score)
    {
        nameText.text = theName;
        scoreText.text = string.Format("{0:00000}" , score);
    }

    public void HideEntryDisplay()
    {
        nameText.text = "";
        scoreText.text = "";
    }

    void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { theName = entryName, score = entryScore });
    }

    public class HighScoreEntry
    {
        public string theName;
        public int score;
    }
}
