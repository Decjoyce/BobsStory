using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Grid : MonoBehaviour
{
    [SerializeField] int speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, );
                        
        }

    }
}
