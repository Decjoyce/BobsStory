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

    private void Start()
    {
        //interaction.GetComponent<Interation>();
        player = GameManager.instance.playerRef.transform;
    }

    private void Update()
    {

                Vector3 direction = transform.position - player.transform.position;
                Vector3 rot = Quaternion.LookRotation(direction).eulerAngles;
                transform.rotation = Quaternion.Euler(0, rot.y, 0);

    }
}

