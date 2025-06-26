using UnityEngine;

public class playerLaserBehavior : MonoBehaviour
{
    //speed variable for laser
    [SerializeField]
    private float _laserSpeed = 8f;
  

    // Update is called once per frame
    void Update()
    {
        
        //translate laser up on the y axis
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime );

      
        //this will check if the laser is out of the screen bounds 
        //then destroy the laser
        if(transform.position.y >= 7)
        {
            Destroy(this.gameObject);
        }
        
    }
}
