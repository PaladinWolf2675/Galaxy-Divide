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
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _nextFire = 0.0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
   private bool _isTripleShotEnabled = false;

    

   
    

    // Start is called before the first frame update
    void Start()
    {
       
        transform.position = new Vector3(0, 0, 0);
        //find the object Get the component
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
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

          if (_isTripleShotEnabled == true)
        {
           Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
          else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
           

           //if space key pressed 
           //if triple shot is true
                //fire three lasers (triple shot prefab)

           //else fire 1 laser

           
           // instantiate 3 lasers (triple shot prefab)
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
           _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
