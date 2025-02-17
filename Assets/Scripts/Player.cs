using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// To create a variable requires three components with an optional fourth
    /// 1. public or private reference - If the variable is public, other scripts can communicate with it. If the variable is private, other scripts cannot communicate with it. 
    /// 2. data type - int (whole number 3, -21) float - (Decimal number - 3.25f) bool (true or false value) string (A word or phrase. "Hello World" ) 
    /// 3. every variable needs a name 
    /// 4. optional value
    /// 
    /// To extract methods from code. 
    /// CTRL+R then CTRL+M
    /// This will create a new method from the selected code 
    /// 
    /// </summary>
    
    
   

    [SerializeField]
    private float _playerMovementSpeed = 5;

    

    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

    }

    private void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Time.deltaTime = real world time 1 meter per second
        transform.Translate(Vector3.right * horizontalInput * _playerMovementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _playerMovementSpeed * Time.deltaTime);

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
}
