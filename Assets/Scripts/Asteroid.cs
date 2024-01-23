using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;
    [SerializeField]
    private float _asteroidSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate this object on Z axis
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime, Space.Self);
        //move asteriod down on Y axis without rotation effecting movement
        transform.Translate(Vector3.down * _asteroidSpeed * Time.deltaTime, Space.World);
    }
}
