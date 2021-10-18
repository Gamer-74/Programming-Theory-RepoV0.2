using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameManager gameManager;

    private int m_ScoreValue = 30;
    private float m_Speed = 14;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Speed();
        ScoreToAdd(m_ScoreValue);
    }

    public virtual void Speed()
    {
        float speed = m_Speed;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public virtual void ScoreToAdd(int ScoreValue)
    {
        m_ScoreValue = ScoreValue;
    }
}
