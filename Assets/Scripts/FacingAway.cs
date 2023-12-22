using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FacingAway : MonoBehaviour
{
    Transform player;
    bool playerIsNear;
    public float turnSmoothTime = 0.1f;
    Transform ogRot;


    private void Start()
    {
        ogRot = transform;
        player = GameManager.instance.playerRef.transform;
    }

    private void Update()
    {
        if (playerIsNear)
        {
            Vector3 direction = transform.position - player.transform.position;
            Vector3 rot = Quaternion.LookRotation(-direction).eulerAngles;
            float newRot = Mathf.LerpAngle(transform.rotation.y, rot.y, turnSmoothTime * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, newRot, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            transform.rotation = ogRot.rotation;
        }
    }

}

