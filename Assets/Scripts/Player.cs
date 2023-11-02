using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // requirements for variables
    // public or private reference
    // data type (int, float, bool, string)
    // (optional) value assigned
    // public variables can be modified inside Unity inspector
    // use underscore for private variables ex private float _speed = 1.0f;
    // if private variables need to be modified use [SerializeField] above variable in the code
    [SerializeField]
    private float _speed = 5f;

     // Create an input system for player movement
    // Variable for horizontal movement input
    // Variable for vertical movement input
    // Both variables public
    // Both variables type float

   
    

    // Start is called before the first frame update
    void Start()
    {
        // set player starting position = new position (0, 0, 0)
        // always use new Vector3
        transform.position = new Vector3(0, 0, 0);

        
    }

    // Update is called once per frame
    void Update()
    {
          // Allow for User input on horizontal axis
       float horizontalInput = Input.GetAxis("Horizontal");

        // Allow for User input on vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        
        // Make player move at normal speed.
        // Multiply Vector3 By _speed by time.deltatime(real time)
        // Add in axis variables for user input
        // new Vector3(0, 0, 0);  (x, y, z)
        // Vector3 can be used as variable type- Vector3 direction = new vector3(horizontalInput, verticalInput, 0);
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(direction * _speed * Time.deltaTime);


       
    }
}
