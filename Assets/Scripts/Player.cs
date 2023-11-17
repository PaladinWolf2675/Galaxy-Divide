using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _nextFire = 0.0f;
    [SerializeField]
    private int _lives = 3;

    

   
    

    // Start is called before the first frame update
    void Start()
    {
       
        transform.position = new Vector3(0, 0, 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Input.GetKeyDown("space") && Time.time > _nextFire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
             // Allow for User input on horizontal axis
       float horizontalInput = Input.GetAxis("Horizontal");

        // Allow for User input on vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        

        transform.Translate(direction * _speed * Time.deltaTime);

         // Clamp value in Vector3 will restrict movement on y axis

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.9f, 0), 0);

        // if player position on x is greater than 12.5f
        // x position = -12.5f
        // else if player position on x is less than -12.5f
        // x position = 12.5f

        if (transform.position.x >= 12.5f)
        {
            transform.position = new Vector3(-12.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -12.5f)
        {
            transform.position = new Vector3(12.5f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
          _nextFire = Time.time + _fireRate;
           Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;

        //check if dead
        //if dead 
        //destroy us

        // issue with code 
        // lives value defaults to 1 at game start
        // cause unknown

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
