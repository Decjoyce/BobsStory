using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sleep : MonoBehaviour
{
    public UnityEvent OnEnterInteraction, OnExitInteraction, OnInteract;
    [SerializeField] KeyCode interactionKey = KeyCode.F;
    [SerializeField] KeyCode altInteractionKey = KeyCode.Space;

    public bool canInteract;

    private void Update()
    {
        if (canInteract && (Input.GetKeyDown(interactionKey) || Input.GetKeyDown(altInteractionKey) || Input.GetButtonDown("Submit")))
        {
            OnInteract.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnterInteraction.Invoke();
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
        canInteract = false;
    }
}
