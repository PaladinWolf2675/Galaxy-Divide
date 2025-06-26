using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerMovementSpeed = 5;
    [SerializeField]
    private GameObject _playerLaserPrefab;
    [SerializeField]
    private float _laserFireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

    private EnemySpawner _enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        _enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();
        
        
        if ( _enemySpawner == null)
        {
            Debug.LogError("The Enemy Spawner is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

       if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
        

    }

    private void FireLaser()
    {
        _canFire = Time.time + _laserFireRate;
        Instantiate(_playerLaserPrefab, transform.position + new Vector3(0, 1.12f, 0), Quaternion.identity);
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //cut to top of code values would stay variables to top

        // Time.deltaTime = real world time 1 meter per second
        transform.Translate(Vector3.right * horizontalInput * _playerMovementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _playerMovementSpeed * Time.deltaTime);

        //calling these seperate will double movement if player moves diagonally
        // vector3 playerMovement = newVector3 (horizontalInput, verticalIput, 0)

        //if player position on the y axis is greater than 6
        //y position = 6
        //else if y position less than -4
        //y position = -4
        //this should wrap the player on the y axis

        if (transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        //if player position on the x axis is greater than 11.5
        //x position = -11.5
        //else if x position less than -11.5
        //x position = 11.5
        //this should wrap the player on the x axis


        if (transform.position.x >= 11.5)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.5)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives--;

        

        if (_lives == 0)
        {
            //Communicate with Enemy Spawner Script
            
            //Tell to stop spawning
            _enemySpawner.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
