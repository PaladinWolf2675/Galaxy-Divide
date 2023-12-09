using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at speed of 3 -need variable and serialize field
        //when we leave screen destroy this game object
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }

    }
    //OnTriggerCollision
    //Only to be collected by the player (Need tags)
    //on collected destroy this game object

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
