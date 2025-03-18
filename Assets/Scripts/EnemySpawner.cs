using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public int enemiesPerWave = 3;
    public float timeBetweenWaves = 5f;
    public float spawnDelay = 0.5f;

    private int currentWave = 0;
    private bool isPlayerAlive = true; // Track if player is alive

    [Header("Player Reference")]
    public GameObject player; // Assign player in the Inspector

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (isPlayerAlive) // Only run waves if player is alive
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            if (!isPlayerAlive) yield break; // Stop if player died

            currentWave++;
            Debug.Log("Starting Wave " + currentWave);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }

            enemiesPerWave += 2;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || !isPlayerAlive) return;

        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, 7f, 0f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Enemy Spawned at " + spawnPosition);
    }

    public void OnPlayerDeath()
    {
        isPlayerAlive = false;
        Debug.Log("Player has died! Stopping enemy waves.");
    }
}
