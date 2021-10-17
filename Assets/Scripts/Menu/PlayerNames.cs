using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerNames : MonoBehaviour
{
    public InputField playerNames;
    public GameObject inputField;

    public static string theName { get; private set; }

    private int usersCount;
    private string[] userNames;
    
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(transform.gameObject);

        usersCount = PlayerPrefs.GetInt("UsersCount", 0);
        if(usersCount > 0)
        {
            userNames = new string[usersCount];
            for (int index = 0; index < usersCount; index++) 
            {
                userNames[index] = PlayerPrefs.GetString("User" + index, string.Empty);
            }
        }
    }

    public string SetNames(string theName)
    {
        theName = inputField.GetComponent<Text>().text;
        playerNames.GetComponent<Text>().text = theName;

        DontDestroyOnLoad(gameObject);
        return theName;
    }

    public void ClickSaveButton()
    {
        PlayerPrefs.SetString("UsersCount", playerNames.text);
        Debug.Log("Your Name Is " + PlayerPrefs.GetString("UsersCount"));
    }

    [System.Serializable]

    class SaveData
    {
        public string theName;
    }
          

    public void SaveUserName()
    {
        SaveData data = new SaveData();
        data.theName = theName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
        PlayerPrefs.SetString("User" + usersCount, playerNames.text);
        usersCount++;
        PlayerPrefs.SetInt("UsersCount", usersCount);
    }

    public void LoadUserName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            theName = data.theName;
        }
        
        PlayerPrefs.GetString("User" + usersCount, playerNames.text);
        usersCount++;
        PlayerPrefs.GetInt("UsersCount", usersCount);
    }
}