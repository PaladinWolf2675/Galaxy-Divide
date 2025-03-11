using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
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
    
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
        //while loop (infinite loop)
           //Instantiate enemy prefab
           //yield wait for 5 seconds
           //stop coroutine if player dies
           //stop coroutine if x number of enemies is defeted
    }

}
