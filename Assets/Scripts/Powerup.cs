using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at speed of 3 be sure to serialize
        //when we leave the screen
        //destroy us
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y <= -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //OnTriggerCollision
    //Only be collectable by the player 
    //Check for player tag
    //on collision with player 
    //destroy us

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy (this.gameObject);
        }
    }
}
