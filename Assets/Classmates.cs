using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classmates : MonoBehaviour
{
    private Interact interact;
    [SerializeField] GameObject talkMenu;
    [SerializeField] CinemachineVirtualCamera talkCam;
    [SerializeField] Transform returnPosition;

    private void Start()
    {
        interact = GetComponent<Interact>();
    }

    public void EnterInteraction()
    {
        //Testing
        interact.OnExitInteraction.Invoke();
        interact.enabled = false;
        GameManager.instance.gamePaused = true;
        talkMenu.SetActive(true);
        talkCam.Priority = 10;
        CameraManager.instance.currentCam.Priority = 0;
    }

    public void ExitInteraction()
    {
        //Testing
        interact.enabled = true;
        GameManager.instance.gamePaused = false;
        CameraManager.instance.currentCam.Priority = 10;
        talkCam.Priority = 0;
        talkMenu.SetActive(false);
        interact.OnEnterInteraction.Invoke();
    }
}
