using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] Transform receiver;
    [SerializeField] bool interactToTeleport;
    [SerializeField] string roomName; //Determines which room it will switch to {Class, Hallway, Canteen}

    //Checks if player enters collider, if so calls the function TeleportPlayer
    private void OnTriggerEnter(Collider other)
    {
        if (!interactToTeleport && other.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }

    //Sets the players position to the receiver, changes from the current cam to the receiver cam and sets the current cam to the receiver cam
    public void TeleportPlayer()
    {
        GameManager.instance.playerRef.transform.position = receiver.position;
        GameManager.instance.playerGraphicsRef.transform.rotation = receiver.rotation;
        GameManager.instance.ChangeRoom(roomName);
    }

}
