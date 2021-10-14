using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xUpSpawnRange = 23;
    private float zUpSpawnRange = 16;
    private float zMinSideSpawn = 0;
    private float zMaxSideSpawn = 10;

    private float startDelay = 1.2f;
    private float spawnInterval = 2.2f;

    public GameObject[] animalPrefab;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnUpAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
    }

    private void Update()
    {
        
    }

    private void SpawnUpAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xUpSpawnRange, xUpSpawnRange), 0, zUpSpawnRange);

        if(gameManager.isGameActive == true)
        {
            Instantiate(animalPrefab[animalIndex], spawnPos, animalPrefab[animalIndex].transform.rotation);
        }
        
    }

    private void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 spawnPos = new Vector3(xUpSpawnRange, 0, Random.Range(zMinSideSpawn, zMaxSideSpawn));
        Vector3 Rotation = new Vector3(0, -90, 0);

        if (gameManager.isGameActive == true)
        {
            Instantiate(animalPrefab[animalIndex], spawnPos, Quaternion.Euler(Rotation));
        }
    }

    private void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 spawnPos = new Vector3(-xUpSpawnRange, 0, Random.Range(zMinSideSpawn, zMaxSideSpawn));
        Vector3 Rotation = new Vector3(0, 90, 0);

        if (gameManager.isGameActive == true)
        {
            Instantiate(animalPrefab[animalIndex], spawnPos, Quaternion.Euler(Rotation));
        }
        
    }
}
