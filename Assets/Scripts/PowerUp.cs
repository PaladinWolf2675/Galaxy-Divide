using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    //ID for powerups
    //0 = Triple Shot
    //1 = Speed Boost
    //2 = Shields
    [SerializeField]
    private int powerupID;

    // Update is called once per frame
    void Update()
    {
        //move down at speed of 3 
        //when we leave screen destroy this game object
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }

    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                //if powerUP is 0
                player.TripleShotActive();
                //else if powerUP is 1
                //activate speed powerUP
                //else if powerUP is 2 
                //activate shield powerUP
            }
            Destroy(this.gameObject);
        }
    }
}
