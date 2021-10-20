using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject nameScoreManager;

    private int m_ScoreValue;
    private float m_Speed;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public virtual void Speed()
    {
        float speed = m_Speed;
    }

    public virtual void AddScore(string name, int ScoreValue)
    {
        m_ScoreValue = ScoreValue;
        name = PlayerPrefs.GetString("UsersCount");
    }
}
