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
        // Make player move at normal speed.
        // Multiply Vector3 By 5 by time.deltatime(real time)
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
