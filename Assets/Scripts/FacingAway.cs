using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FacingAway : MonoBehaviour
{
    Transform player;
    bool playerIsNear;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private Quaternion[] NPCStartRots = new Quaternion[10];

    private void Start()
    {
        //interaction.GetComponent<Interation>();
        player = GameManager.instance.playerRef.transform;
    }

    private void Update()
    {
        if (playerIsNear)
        {
                Vector3 direction = transform.position - player.transform.position;
                Vector3 rot = Quaternion.LookRotation(direction).eulerAngles;
                transform.rotation = Quaternion.Euler(0, rot.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
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
        }
    }
}

