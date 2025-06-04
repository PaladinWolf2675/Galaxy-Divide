using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDrift : MonoBehaviour
{
    public float offset;
    public float multiplier;

    private Vector3 beginOffset;
    private float dif;

    // Use this for initialization
    void Start()
    {
        beginOffset = transform.localPosition;
    }
	
    // Update is called once per frame
    void Update()
    {

        dif = beginOffset.x + (Mathf.Sin(Time.timeSinceLevelLoad + offset) * multiplier);

        transform.localPosition = new Vector3(dif, beginOffset.y, beginOffset.z);
		
    }
}
