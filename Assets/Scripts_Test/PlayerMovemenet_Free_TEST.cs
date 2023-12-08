using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovmenetFreeTest : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject graphics;
    public Animator anim;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public bool isMoving;

    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.gamePaused)
            Movement();
    }

    public void Movement()
    {
        isMoving = true;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

      

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(graphics.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            graphics.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            anim.SetFloat("Speed", 1f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        else
        {
            isMoving = false;
            anim.SetFloat("Speed", 0f);
        }
    }

    public void MovePlayerToPos(Transform newPos)
    {
        characterController.enabled = false;
        transform.position = newPos.position;
        graphics.transform.rotation = newPos.rotation;
        characterController.enabled = true;
    }
}

