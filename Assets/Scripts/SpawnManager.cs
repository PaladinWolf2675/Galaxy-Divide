using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;


    private bool _stopSpawning = false;

    
    

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn game objects every 5 seconds
    //Create a coroutine of type IEnumerator -- Yield Events
    //while loop -- if executed improperly will crash computer

    IEnumerator SpawnEnemyRoutine()
    {

        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
           Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 9f, 0); 
           GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
           newEnemy.transform.parent = _enemyContainer.transform;
           yield return new WaitForSeconds(2.5f);

        }  
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        //every 3-7 seconds spawn powerup
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    // This will Cause Player death
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }


         

}
