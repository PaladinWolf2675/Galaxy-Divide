using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaserBehavior : MonoBehaviour
{
    //speed variable for laser
    [SerializeField]
    private float _laserSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //translate laser up on the y axis
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime );

        //if laser position is greater than 7 on the y axis
        //destroy this game object

        if(transform.position.y >= 7)
        {
            Destroy(this.gameObject);
        }
        
    }
}
