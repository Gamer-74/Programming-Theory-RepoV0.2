using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public HealthBar healthBar;
    public GameManager gameManager;

    public ParticleSystem dirtParticle;
    
    public AudioClip throwCarrot;
    public AudioClip takeDamage;

    private AudioSource audioSource;
    
    private Rigidbody playerRb;

    private float speed = 20;
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 19;
    private float zRange = 8;
    private float zAxis = 0;

    //private int lives = 3;
    
    public int health { get { return currentHealth; } }
    private int maxHealth = 10;
    private int currentHealth;
    private int dead = 0;

    public float timeInvincible = 2.5f;
    bool isInvincible;
    float invincibleTimer;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        PlayerMovement();
        FeedAnimal();
        
    }

    private void PlayerMovement()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            dirtParticle.Play();
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            dirtParticle.Play();
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            dirtParticle.Play();
        }
        if (transform.position.z < zAxis)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);
            dirtParticle.Play();
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }

    private void FeedAnimal()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, projectilePrefab.transform.rotation);
            
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= dead)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
            gameManager.isGameActive = false;
            gameManager.GameOver();
            dirtParticle.Stop();
        }
    }
}
