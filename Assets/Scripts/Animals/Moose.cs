using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moose : Animal
{
    private int m_MScore = 6;
    private float m_MooseSpeed = 8;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {  
        ScoreToAdd(m_MScore);
        Speed();
    }
//Override Method
    public override void ScoreToAdd(int ScoreValue)
    {
        base.ScoreToAdd(ScoreValue);
        ScoreValue += m_MScore;
    }

    public override void Speed()
    {
        base.Speed();
        float speed = m_MooseSpeed;
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
            gameManager.UpdateScore(m_MScore);
        }
    }
}
