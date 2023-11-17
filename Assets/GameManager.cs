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
    public float roomSize;
    public Transform roomStart;

    //Camera
    public CinemachineVirtualCamera currentCam;
    [SerializeField] Transform camPositionClass, camPositionCanteen, camPositionHall;
    [SerializeField] Transform playerLookAt, targetLookAt;
    [SerializeField] CinemachineRecomposer recomposer;
    private float fov;

    private void Start()
    {
        targetLookAt.position = playerLookAt.position;
    }

    private void Update()
    {
        SetCamZoom();
    }

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
    void SetCamZoom()
    {
        float dist = Vector3.Distance(Vector3.zero, playerRef.transform.position);
        float mappedDistance = Mathf.Clamp(ExtensionMethods.Map(dist, 0, roomSize, 1, 0), 0.3f, 1);
        
        recomposer.m_ZoomScale = mappedDistance;
    }

    public void EditCurrentCam(Transform newlookAt = null, float newFov = 0)
    {
        fov = currentCam.m_Lens.FieldOfView;
        targetLookAt.position = newlookAt.position;
        currentCam.m_Lens.FieldOfView = newFov;
    }

    public void ReturnCamToNormal()
    {
        targetLookAt.position = playerLookAt.position;
        currentCam.m_Lens.FieldOfView = fov;
    }
    #endregion
}
