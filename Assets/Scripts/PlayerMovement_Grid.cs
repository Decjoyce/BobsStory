using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Grid : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject graphics;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            transform.Translate(Vector3.forward * speed);
            graphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            transform.Translate(-Vector3.forward * speed);
            graphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
            graphics.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-Vector3.right * speed);
            graphics.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
