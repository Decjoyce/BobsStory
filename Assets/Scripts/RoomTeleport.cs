using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] Transform receiver;
    [SerializeField] bool interactToTeleport;
    [SerializeField] string roomName; //Determines which room it will switch to {Class, Hallway, Canteen}
    Interact interact;

    private void Start()
    {
        interact = GetComponent<Interact>();
    }

    //Sets the players position to the receiver, changes from the current cam to the receiver cam and sets the current cam to the receiver cam
    public void TeleportPlayer()
    {
        interact.ExitInteraction();
        GameManager.instance.playerRef.GetComponent<PlayerMovmenetFreeTest>().MovePlayerToPos(receiver);
        GameManager.instance.ChangeRoom(roomName);
    }

}
