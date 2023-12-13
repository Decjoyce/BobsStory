using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.IO.Pipes;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject talkMenu;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Slider timerBar;
    [SerializeField] private GameObject faceUI;

    [Header("Face UI")]
    [SerializeField] private MakeFriendHandler makefriendUI;
    [SerializeField] private Image dialogueFacePlayer;
    [SerializeField] private Image dialogueFaceNPC;
    [SerializeField] private FaceManager playerFaces;
    [SerializeField] private FaceManager NPCFaces;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    private bool dialoguePlaying;

    public Classmates classmate;
    string typeofClassmate;

    [Header("Tag Handling")]
    [SerializeField] private TextMeshProUGUI displayNameText;

    //ink Tags
    private const string SPEAKER_TAG = "speaker";
    private const string FACE_PLAYER_TAG = "face_player";
    private const string FACE_NPC_TAG = "face_npc";
    private const string STANDING_TAG = "standing";
    private const string CONFIDENCE_TAG = "confidence";
    private const string DECAY_TAG = "decay";
    private const string BUTTON_TAG = "button";
    private const string END_TAG = "end";


    [SerializeField] EventSystem eventSystem;

    //Confidence Meter
    float maxConfidence = 100;
    float decayRateConfidence = 1f;
    float currentConfidence;

    bool atEnd;

    [SerializeField] Volume talkVolume, mainVolume;
    private Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePlaying = false;
        talkMenu.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        talkVolume.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (!dialoguePlaying)
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 && !atEnd)
        {
            ContinueStory();
        }
        if (atEnd && Input.GetButtonDown("Submit"))
        {
            ContinueStory();
        }

        currentConfidence -= decayRateConfidence * Time.deltaTime;
        timerBar.value = currentConfidence;
        vignette.intensity.value = ExtensionMethods.Map(currentConfidence, 0, timerBar.maxValue, 1, 0);

        if (currentConfidence <= 0)
            ExitDialogueMode();
    }

    public void EnterMakeFriendMode()
    {
        makefriendUI.classmateType = classmate.classmateType;
        makefriendUI.gameObject.SetActive(true);
        dialoguePanel.SetActive(false);
    }
    public void ExitMakeFriendMode()
    {
        makefriendUI.classmateType = null;
        makefriendUI.gameObject.SetActive(false);
        dialoguePanel.SetActive(true);
    }

    public void EnterDialogueMode(Classmates mate)
    {
        classmate = mate;
        typeofClassmate = classmate.classmateType.classmateType;
        currentStory = new Story(classmate.classmateType.inkJSONFile.text);
        dialoguePlaying = true;
        talkMenu.SetActive(true);
        faceUI.SetActive(false);
        timerBar.gameObject.SetActive(true);

        talkVolume.gameObject.SetActive(true);
        mainVolume.gameObject.SetActive(false);

        switch (typeofClassmate)
        {
            case "JOCK":
                currentConfidence = maxConfidence * GameManager.jocksStanding / 10 + 10;
                break;
            case "NERD":
                currentConfidence = maxConfidence * GameManager.nerdsStanding / 10 + 10;
                break;
            case "GEEK":
                currentConfidence = maxConfidence * GameManager.geeksStanding / 10 + 10;
                break;
        }
        decayRateConfidence = 1;
        timerBar.maxValue = currentConfidence;

        timerBar.gameObject.SetActive(true);

        //eventSystem.SetSelectedGameObject(choices[0]);

        atEnd = false;
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    public void ExitDialogueMode()
    {
        dialoguePlaying = false;
        talkMenu.SetActive(false);
        dialogueText.text = "";

        faceUI.SetActive(true);
        timerBar.gameObject.SetActive(false);

        classmate.ExitInteraction();
        classmate.GetComponent<Collider>().enabled = false;
        classmate = null;

        atEnd = false;

        vignette.intensity.value = 0;
        talkVolume.gameObject.SetActive(false);
        mainVolume.gameObject.SetActive(true);

        ExitMakeFriendMode();
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
            StopAllCoroutines();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("Need More Choices");
            return;
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }

    void HandleTags(List<string> currentTags) 
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    //displayNameText.text = tagValue;
                    break;
                case FACE_PLAYER_TAG:
                    dialogueFacePlayer.sprite = GetTheFace(tagValue, playerFaces);
                    break;
                case FACE_NPC_TAG:
                    dialogueFaceNPC.sprite = GetTheFace(tagValue, NPCFaces);
                    break;
                case STANDING_TAG:
                    GameManager.instance.IncreaseStanding(typeofClassmate, int.Parse(tagValue));
                    GameManager.instance.playerRef.GetComponent<PlayerStats>().CalculateHappiness();
                    break;
                case CONFIDENCE_TAG:
                    currentConfidence += int.Parse(tagValue);
                    break;
                case DECAY_TAG:
                    decayRateConfidence += float.Parse(tagValue);
                    break;
                case BUTTON_TAG:
                    string[] splitValue = tagValue.Split('.');
                    ButtonTagHandle(splitValue);
                    break;
                case END_TAG:
                    atEnd = true;
                    break;
                default:
                    Debug.LogWarning("Checked Tag is not being Handled: " + tag);
                    break;
            }
        }
    }

    Sprite GetTheFace(string value, FaceManager whoseFace)
    {
        switch (value)
        {
            case "happy":
                return whoseFace.happyFace;
            case "neutral":
                return whoseFace.neutralFace;
            case "sad":
                return whoseFace.sadFace;
            case "depressed":
                return whoseFace.depressedFace;
            default:
                Debug.LogError("Error Incorrect Face");
                return null;
        }
    }

    void ButtonTagHandle(string[] buttonParams)
    {
        string thechoice = buttonParams[0];
        string param = buttonParams[1];
        string[] splitParam = param.Split(';');
        string paramKey = splitParam[0].Trim();
        string paramValue = splitParam[1].Trim();
        switch (paramKey)
        {
            case "time":
                Debug.Log(thechoice + ", " + param);
                StartCoroutine(DisableChoice(float.Parse(paramValue), choices[int.Parse(thechoice)]));
                    break;
        }
    }

    IEnumerator DisableChoice(float delay, GameObject button)
    {
        yield return new WaitForSeconds(delay);
        button.SetActive(false);
    }
}
