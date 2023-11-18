using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classmates : MonoBehaviour
{
    private Interact interact;
    [SerializeField] GameObject talkMenu;

    private void Start()
    {
        interact = GetComponent<Interact>();
    }

    public void EnterInteraction()
    {
        //Testing
        interact.enabled = false;
        GameManager.instance.gamePaused = true;
        talkMenu.SetActive(true);
    }

    public void ExitInteraction()
    {
        //Testing
        interact.enabled = true;
    }
}
