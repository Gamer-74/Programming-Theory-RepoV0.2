using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doe : Animal
{
    private int m_DScore = 8;
    private float m_DoeSpeed = 7;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Speed();
    }

    public override void AddScore(string name, int ScoreValue)
    {
        base.AddScore(name, ScoreValue);
        name = PlayerPrefs.GetString("UsersCount");
        m_DScore = ScoreValue;
        gameManager.UpdateScore(name, m_DScore);
    }

    //Override Method
    public override void Speed()
    {
        base.Speed();
        float speed = m_DoeSpeed;
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
        else if (other.gameObject)
        {
            Destroy(gameObject);
            AddScore(name, m_DScore);
        }
    }
}
