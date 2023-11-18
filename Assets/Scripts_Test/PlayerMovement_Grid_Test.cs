using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement_Grid_Test : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject graphics;
    
    [Header("SoundEffects")]
    [SerializeField] GameObject footsteps;
    private float FootDelay = 0.3f;
    
    private void Start()
    {
        //Audio
        footsteps.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Audio
            footstep();
           
            
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            transform.Translate(Vector3.forward * speed);
            graphics.transform.rotation = Quaternion.Euler(0, 0, 0);
            
            //AudioStop
            Invoke(nameof(StopFootSteps), FootDelay);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Audio
            footstep();
            
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            transform.Translate(-Vector3.forward * speed);
            graphics.transform.rotation = Quaternion.Euler(0, 180, 0);
            
            //AudioStop
            Invoke(nameof(StopFootSteps), FootDelay);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Audio
            footstep();
            
            graphics.transform.rotation = Quaternion.Euler(0, 90, 0);
            
            //AudioStop
            Invoke(nameof(StopFootSteps), FootDelay);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Audio
            footstep();
            
            graphics.transform.rotation = Quaternion.Euler(0, -90, 0);
            
            //AudioStop
            Invoke(nameof(StopFootSteps), FootDelay);
        }
        
    }

    void footstep()
    {
        //Play Audio
        footsteps.SetActive(true);
    }

    void StopFootSteps()
    {
        //Stop Audio
        footsteps.SetActive(false);
    }

    
}
