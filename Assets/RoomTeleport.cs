using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera receiverCam;
    [SerializeField] Transform receiver;

    //Checks if player enters collider, if so calls the function TeleportPlayer
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    //Sets the players position to the receiver, changes from the current cam to the receiver cam and sets the current cam to the receiver cam
    void TeleportPlayer(GameObject player)
    {
        player.transform.position = receiver.position;
        GameManager.instance.currentCam.Priority = 0;
        receiverCam.Priority = 50;
        GameManager.instance.currentCam = receiverCam;
    }
}
