using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public UnityEvent OnEnterInteraction, OnExitInteraction, OnInteract;
    [SerializeField] KeyCode interactionKey = KeyCode.F;
    [SerializeField] KeyCode altInteractionKey = KeyCode.Space;
    [SerializeField] Transform camLookAt;
    
    public AudioSource Source;
    
    public bool canInteract;

    private void Update()
    {
        if(canInteract && (Input.GetKeyDown(interactionKey) || Input.GetKeyDown(altInteractionKey) || Input.GetButtonDown("Submit")))
        {
            OnInteract.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnterInteraction.Invoke();
            FocusCam();
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExitInteraction();
        }
    }

    public void ExitInteraction()
    {
            OnExitInteraction.Invoke();
            UnFocusCam();
            canInteract = false;
    }

    void FocusCam()
    {
        CameraManager.instance.FocusCameraOnObject(camLookAt);        
    }

    public void UnFocusCam()
    {
        CameraManager.instance.UnFocusCamera();
    }

    public void Bell()
    {
        Source.PlayDelayed(1.8f);
    }
}
