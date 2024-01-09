using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField]
    private float _speed = 5f;
    private float _speedMultiplier = 2;
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


    private bool _isShieldsActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isTripleShotActive = false;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private int _score;
   

    

   
    

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

        
        transform.Translate(direction * _speed *  Time.deltaTime); 
      
         
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

          if (_isTripleShotActive == true)
        {
           Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
          else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }

    }

    public void Damage()
    {
        //if shield powerup is active
        //do nothing
        //deactivate shields after 1 hit to player
        if (_isShieldsActive == true)
        {
            _isShieldsActive = false;
            //disable visualizer
            _shieldVisualizer.SetActive(false);
            return;
        }
        _lives--;

        if (_lives < 1)
        {
           _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
         
    }
    //wait 5 seconds
    //set the triple shot to false

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedboostPowerDownRoutine());
    }

    IEnumerator SpeedboostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }

    public void ShieldsActive()
    {
        _isShieldsActive = true;
        //enable visualizer
        _shieldVisualizer.SetActive(true);
    }

    //method to add 10 to score
    public void AddScore()
    {
        _score += 10;
    }
    //Communicate with the UI to update the score

  
}
