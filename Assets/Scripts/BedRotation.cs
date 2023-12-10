using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRotation : MonoBehaviour
{

    public float turnSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Rotate(0,turnSpeed * Time.deltaTime, 0);
        
        

    }
}
