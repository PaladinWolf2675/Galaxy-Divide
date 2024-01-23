using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;
    [SerializeField]
    private float _asteroidSpeed = 4f;
    [SerializeField]
    private GameObject _explosionPrefab;
  


    // Update is called once per frame
    void Update()
    {
        //rotate this object on Z axis
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime, Space.Self);
        //move asteriod down on Y axis without rotation effecting movement
        transform.Translate(Vector3.down * _asteroidSpeed * Time.deltaTime, Space.World);
    }

    //check for LASER collision (trigger)
    //instantiate explosion at the position of the asteroid (this game object)
    //destroy the explosion after 3 seconds.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
        }
    }
}
