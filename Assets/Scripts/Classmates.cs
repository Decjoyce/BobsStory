using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classmates : MonoBehaviour
{
    private Interact interact;
    [SerializeField] private DialogueManager dm;
    [SerializeField] CinemachineVirtualCamera talkCam;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Transform[] modelPositions;
    [SerializeField] bool isSitting;
    public ClassmateType classmateType;
    public GameOverDialogue gameOverDialogue;


    private void Start()
    {
        interact = GetComponent<Interact>();
    }

    public void EnterInteraction()
    {
        interact.OnExitInteraction.Invoke();
        interact.enabled = false;
        GameManager.instance.gamePaused = true;
        talkCam.Priority = 10;
        CameraManager.instance.currentCam.Priority = 0;
        GameManager.instance.playerRef.GetComponentInChildren<PlayerHeartbeat>().enabled = false;
        dm.EnterDialogueMode(this);
    }

    public void ExitInteraction()
    {
        interact.enabled = true;
        GameManager.instance.gamePaused = false;
        CameraManager.instance.currentCam.Priority = 10;
        talkCam.Priority = 0;
        GameManager.instance.playerRef.GetComponentInChildren<PlayerHeartbeat>().enabled = true;
        interact.ExitInteraction();
    }

    public void ChangeType(ClassmateType type)
    {
        classmateType = type;
        classmateType.ChangeModels(modelPositions, isSitting);
    }


}
