using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        // Multiply Vector3 By Unity unit by time.deltatime(real time)
        transform.Translate(Vector3.right * 5 * Time.deltaTime);
    }
}
