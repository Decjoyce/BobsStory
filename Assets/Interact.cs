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
    [SerializeField] float focusFov;

    public bool canInteract;

    private void Update()
    {
        if(canInteract && (Input.GetKeyDown(interactionKey) || Input.GetKeyDown(altInteractionKey)))
        {
            OnInteract.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnterInteraction.Invoke();
            //FocusCam();
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnExitInteraction.Invoke();
            //UnFocusCam();
            canInteract = false;
        }
    }

    void FocusCam()
    {
        GameManager.instance.EditCurrentCam(camLookAt,focusFov);        
    }

    void UnFocusCam()
    {
        GameManager.instance.ReturnCamToNormal();
    }
}
