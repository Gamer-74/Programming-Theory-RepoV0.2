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
        ScoreToAdd(m_SScore);
        Speed();
    }

    public override void ScoreToAdd(int ScoreValue)
    {
        base.ScoreToAdd(ScoreValue);
        ScoreValue = m_SScore;
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
            gameManager.UpdateScore(m_SScore);
        }
    }
}
