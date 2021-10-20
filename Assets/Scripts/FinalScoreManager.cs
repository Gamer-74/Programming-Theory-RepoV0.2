using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class FinalScoreManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public GameObject finalScore;
    public static string theFinal { get;  private set; }
    private int finalScores;
    private string[] finalsScores;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(transform.gameObject);

        finalScores = PlayerPrefs.GetInt("FinalScores", 0);
        if(finalScores > 0)
        {
            finalsScores = new string [finalScores];
            for(int index = 0; index < finalScores; index++)
            {
                finalsScores[index] = PlayerPrefs.GetString("Final" + index, string.Empty);
            }
        }
    }

    public string SetNameScore(string theFinal)
    {
        theFinal = gameObject.GetComponent<Text>().text;
        finalScore.GetComponent<Text>().text = theFinal;

        DontDestroyOnLoad(gameObject);
        return theFinal;
    }

    public void SaveNameScore()
    {
        PlayerPrefs.SetString("theFinal", finalScoreText.text.ToString());
        Debug.Log("Final Score is " + PlayerPrefs.GetString("theFinal"));
    }

    class SaveData
    {
        public string finalScore;
    }

    public void SaveFinalScore()
    {
        SaveData data = new SaveData();
        data.finalScore = theFinal.ToString();

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        PlayerPrefs.SetString("theFinal" + finalScores, finalScoreText.text);
        finalScores++;
        PlayerPrefs.SetInt("FinalScores", finalScores);
    }

    public void LoadFinalScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            theFinal = data.finalScore;
        }
        PlayerPrefs.GetString("theFinal"+ finalScores, finalScoreText.text);
        finalScores++;
        PlayerPrefs.GetInt("FinalScores", finalScores);
    }
}