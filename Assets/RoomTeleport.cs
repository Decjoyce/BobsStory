using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera roomCam;
    [SerializeField] Transform receiver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    void TeleportPlayer(GameObject player)
    {
        player.transform.position = receiver.position;
        roomCam.Priority = 50;
    }
}
