using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // move enemy down 4 meters per second
           transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        //if bottom of screen 
        //respawn at top with new random x position

        if(transform.position.y <= -5f)
        {
            float Randomx = Random.Range(-9f, 9f);
           transform.position = new Vector3(Randomx, 9f, 0);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        // if other is player
        // damage player 
        // Destroy Us

        // if other is Laser
        // Destroy Laser
        // Destroy Us
    }
}
