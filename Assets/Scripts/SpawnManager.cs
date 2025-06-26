using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // spawn enemy every 5 seconds
    // after set number of enemies destroyed
    // end level
    // Create a coroutine of type IEnumerator -- Yield Events
    // while loop
    // total enemies = 10 * levelNumber if level is not timed level
    // if _spawnCount = 0 and player is not dead
    // player wins 
    // else game over
    
    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
        //while loop (infinite loop)
           //Instantiate enemy prefab
           //yield wait for 5 seconds
           //stop coroutine if player dies
           //stop coroutine if x number of enemies is defeted
    }

    public void OnPlayerDeath ()
    {
        _stopSpawning = false;
    }

}
