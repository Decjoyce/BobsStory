using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    //Sets up an instance to this script so all other scripts can reference it
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("MORE THAN ONE INSTANCE OF " + this.name + " FOUND");
            return;
        }
        instance = this;
    }
    #endregion

    public CinemachineVirtualCamera currentCam;
    public string currentRoom;

}
