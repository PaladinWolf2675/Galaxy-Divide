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
    /// </summary>
    public float playerMovementSpeed = 5; 

    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime = real world time 1 meter per second
        transform.Translate(Vector3.right * playerMovementSpeed * Time.deltaTime);
    }
}
