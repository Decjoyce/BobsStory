using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //Sets up an instance to this script so all other scripts can reference it
    #region Singleton
    public static GameManager instance;
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

    //References
    public GameObject playerRef;
    public GameObject playerGraphicsRef;
    public EventSystem eventSystemRef;

    //Functionality
    public bool gamePaused = false;
    public static int day;
    public bool afternoon;

    //Room
    public string currentRoom;
    [SerializeField] GameObject roomHall, roomClass, roomCanteen;
    [SerializeField] CameraManager camManager;


    //Effects
    [SerializeField] Animator fadeAnim;

    private void Start()
    {
        ChangeRoom("Hallway");
    }

    public void SkipToAfternoon()
    {
        StartCoroutine(TransitionToAfternoon());
    }

    IEnumerator TransitionToAfternoon()
    {
        fadeAnim.SetBool("fade", true);
        yield return new WaitForSeconds(3f);
        fadeAnim.SetBool("fade", false);
        afternoon = true;
    }

    public void ChangeRoom(string nameOfRoom)
    {
        switch (nameOfRoom)
        {
            case "Hallway":
                currentRoom = nameOfRoom;
                camManager.ChangeCamera(roomHall.transform.position, 20, 0);
                SetActiveRoom("Hallway");
                break;
            case "Class":
                currentRoom = nameOfRoom;
                camManager.ChangeCamera(roomClass.transform.position, 35, 1);
                SetActiveRoom("Class");
                break;
            case "Canteen":
                currentRoom = nameOfRoom;
                camManager.ChangeCamera(roomCanteen.transform.position, 25, 2);
                SetActiveRoom("Canteen");
                break;
            default:
                Debug.LogError("Invalid Room");
                break;
        }
    }

    void SetActiveRoom(string activeroom)
    {
        switch (activeroom)
        {
            case "Hallway":
                roomHall.SetActive(true);
                roomClass.SetActive(false);
                roomCanteen.SetActive(false);
                break;
            case "Class":
                roomClass.SetActive(true);
                roomHall.SetActive(false);
                roomCanteen.SetActive(false);
                break;
            case "Canteen":
                roomCanteen.SetActive(true);
                roomClass.SetActive(false);
                roomHall.SetActive(false);
                break;
            default:
                Debug.LogError("Invalid Room");
                break;
        }
    }
}
