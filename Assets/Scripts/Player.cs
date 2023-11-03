using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField]
    private float _speed = 5f;

    

   
    

    // Start is called before the first frame update
    void Start()
    {
       
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
        
        

        transform.Translate(direction * _speed * Time.deltaTime);

        // if player position on y is greater than 0
        // y position = 0
        // else if player position on y is less than -3.9f
        // y position = -3.9f

        if (transform.position.y >= 0)
        {
             transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }



       
    }
}
