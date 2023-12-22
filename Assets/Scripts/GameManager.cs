using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using static PlayerStats;
using UnityEngine.SceneManagement;
using TMPro;

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
        cm = GetComponent<ClassmateManager>();
        if (!gameHasStarted)
        {
            jocksStanding = startingstanding_Jocks;
            nerdsStanding = startingstanding_Nerds;
            geeksStanding = startingstanding_Geeks;
        }
            
        gameHasStarted = true;
    }
    #endregion

    [SerializeField] bool menu;

    //References
    public GameObject playerRef;
    public GameObject playerGraphicsRef;
    public GameObject bench;
    public GameObject Bed;
    public GameObject BenchMainMenu;
    public EventSystem eventSystemRef;

    private ClassmateManager cm;
    [SerializeField] MainMenu mainMenu;
    [SerializeField] LevelLoader levelLoader;

    //Functionality
    public static bool gameHasStarted;
    public bool gamePaused = false;
    public static int week;
    public bool afternoon;
    public bool WeekChange = false;

    public static int jocksStanding, nerdsStanding, geeksStanding;
    [SerializeField] private int startingstanding_Jocks, startingstanding_Nerds, startingstanding_Geeks;

    public PlayerEmotionalState emotionalState;

    //Room
    public string currentRoom;
    [SerializeField] GameObject roomHall, roomClass, roomCanteen;
    [SerializeField] CameraManager camManager;
    bool gameHappening;

    [SerializeField] TextMeshProUGUI weekText;

    //Effects
    [SerializeField] Animator fadeAnim;

    private void Start()
    {
        if(!menu)
            ChangeRoom("Hallway");
        else
        {
            if(weekText != null)
            weekText.text = "Week " + (week + 1);
        }
    }
    
    public void ResetGame()
    {
        gameHasStarted = false;
    }

    public void GameOver()
    {
        levelLoader.LoadLevel(4);
        //bench.SetActive(true);
        BenchMainMenu.SetActive(true);
        Bed.SetActive(false);
    }

    public void SkipToAfternoon()
    {
        week++;
        levelLoader.LoadLevel(2);
        Debug.Log(week);
        if(week > 0)
        {
            WeekChange = true;
        }

    }

    

    public void IncreaseStanding(string classmateType, int amount)
    {
        switch (classmateType)
        {
            case "JOCK":
                jocksStanding += amount;
                break;
            case "NERD":
                nerdsStanding += amount;
                break;
            case "GEEK":
                geeksStanding += amount;
                break;
        }
    }

    public int GetStanding(string classmateType)
    {
        switch (classmateType)
        {
            case "JOCK":
                return jocksStanding;
            case "NERD":
                return nerdsStanding;
            case "GEEK":
                return geeksStanding;
            default:
                return -1;
        }
    }

    public void ChangeRoom(string nameOfRoom)
    {
        switch (nameOfRoom)
        {
            case "Hallway":
                currentRoom = nameOfRoom;
                camManager.ChangeCamera(roomHall.transform.position, 45, 0);
                SetActiveRoom("Hallway");
                break;
            case "Class":
                currentRoom = nameOfRoom;
                camManager.ChangeCamera(roomClass.transform.position, 35, 1);
                SetActiveRoom("Class");
                break;
            case "Canteen":
                currentRoom = nameOfRoom;
                camManager.ChangeCamera(roomCanteen.transform.position, 55, 2);
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
