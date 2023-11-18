using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Singleton
    public static CameraManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("MORE THAN ONE INSTANCE OF " + this.name + " FOUND");
            return;
        }
        instance = this;
    }
    #endregion


    [SerializeField] GameObject playerRef;

    private float roomSize;
    private Vector3 roomStart;

    public CinemachineVirtualCamera currentCam;
    [SerializeField] Transform[] camRoomPositions;
    [SerializeField] Transform playerLookAt;   
    [SerializeField] CinemachineTargetGroup targetGroup;
    private CinemachineRecomposer recomposer;
    private Transform targetLookAt;

    private void Start()
    {
        recomposer = currentCam.GetComponent<CinemachineRecomposer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetCamZoom();
    }

    void SetCamZoom()
    {
        float dist = Vector3.Distance(roomStart, playerRef.transform.position);
        float mappedDistance = Mathf.Clamp(ExtensionMethods.Map(dist, 0, roomSize, 1, 0), 0.3f, 1);

        recomposer.m_ZoomScale = Mathf.Lerp(recomposer.m_ZoomScale, mappedDistance, 2f * Time.deltaTime); ;
    }

    public void ChangeCamera(Vector3 newRoomStart, float newRoomSize, int camIndex)
    {
        roomSize = newRoomSize;
        roomStart = newRoomStart;
        currentCam.transform.position = camRoomPositions[camIndex].position;
    }

    public void FocusCameraOnObject(Transform newlookAt)
    {
        targetLookAt = newlookAt;
        targetGroup.AddMember(newlookAt, 1, 0);
    }

    public void UnFocusCamera()
    {
        targetGroup.RemoveMember(targetLookAt);
        targetLookAt = null;
    }
}
