using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
   
    [SerializeField]//0 = Triple Shot 1 = Speed Boost 2 = Shields
    private int powerupID;
    [SerializeField]
    private AudioClip _clip;

 

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

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (player != null)
            {  
              switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
            }
           
            Destroy(this.gameObject);
        }
    }
}
