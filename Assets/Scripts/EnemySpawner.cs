using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab; // Assign enemy prefab in Inspector
    public int enemiesPerWave = 3; // Number of enemies in the first wave
    public float timeBetweenWaves = 5f; // Time delay between waves
    public float spawnDelay = 0.5f; // Delay between individual spawns
    [SerializeField]
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true) // Infinite waves (add stopping condition if needed)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            currentWave++;

            Debug.Log("Starting Wave " + currentWave);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }

            // Increase enemies per wave for progressive difficulty
            enemiesPerWave += 2;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        // Generate a random position within the given range
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, 7f, 0f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Enemy Spawned at " + spawnPosition);
    }
}
