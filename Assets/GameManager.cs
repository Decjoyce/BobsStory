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

    //References
    public GameObject playerRef;

    //Room
    public string currentRoom;

    //Camera
    public CinemachineVirtualCamera currentCam;
    [SerializeField] Transform camPositionClass, camPositionCanteen, camPositionHall;
    [SerializeField] Transform playerLookAt;
    private float fov;

    public void ChangeRoom(string nameOfRoom)
    {
        switch (nameOfRoom)
        {
            case "Class":
                currentRoom = nameOfRoom;
                currentCam.transform.position = camPositionClass.position;
                break;
            case "Canteen":
                currentRoom = nameOfRoom;
                currentCam.transform.position = camPositionCanteen.position;
                break;
            case "Hallway":
                currentRoom = nameOfRoom;
                currentCam.transform.position = camPositionHall.position;
                break;
            default:
                Debug.LogError("Invalid Room");
                break;
        }
    }

    #region Camera Stuff
    public void EditCurrentCam(Transform newlookAt = null, float newFov = 0)
    {
        fov = currentCam.m_Lens.FieldOfView;
        currentCam.LookAt = newlookAt;
        currentCam.m_Lens.FieldOfView = newFov;
    }

    public void ReturnCamToNormal()
    {
        currentCam.LookAt = playerLookAt;
        currentCam.m_Lens.FieldOfView = fov;
    }
    #endregion
}
