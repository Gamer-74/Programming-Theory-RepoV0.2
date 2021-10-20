using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stag : Animal
{
    private int m_SScore = 10;
    private float m_StagSpeed = 6;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Speed();
    }
//Override Method
    public override void AddScore(string name, int ScoreValue)
    {
        base.AddScore(name, ScoreValue);
        name = PlayerPrefs.GetString("UsersCount");
        m_SScore = ScoreValue;
        gameManager.UpdateScore(name, m_SScore);
    }

    public override void Speed()
    {
        base.Speed();
        float speed = m_StagSpeed;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.ChangeHealth(-1);
        }
        else if(other.gameObject)
        {
            Destroy(gameObject);
            AddScore(name, m_SScore);
        }
    }
}
