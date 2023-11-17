using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classmates : MonoBehaviour
{
    [SerializeField] Transform lookAt;

    public void EnterInteraction()
    {
        GameManager.instance.currentCam.LookAt = lookAt;
    }

    public void ExitInteraction()
    {
        GameManager.instance.ReturnCamToNormal();
    }
}
