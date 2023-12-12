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
using Cinemachine;

public class MotherDialogue : MonoBehaviour
{
    public GameObject PressSpace;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    private bool dialoguePlaying;

    [Header("Tag Handling")]
    [SerializeField] private TextMeshProUGUI displayNameText;

    //ink Tag
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string STANDING_TAG = "standing";
    private const string CONFIDENCE_TAG = "confidence";
    private const string DECAY_TAG = "decay";
    private const string BUTTON_TAG = "button";
    private const string END_TAG = "end";

    public TextAsset inkJSONFile;

    [SerializeField] EventSystem eventSystem;
    [SerializeField] CinemachineVirtualCamera talkCam;

    bool atEnd;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        PressSpace.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        EnterDialogueMode();

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
    }

    public void EnterDialogueMode()
    {
        GameManager.instance.gamePaused = true;
        currentStory = new Story(inkJSONFile.text);
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);


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

    private void ExitDialogueMode()
    {
        GameManager.instance.gamePaused = false;
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        talkCam.Priority = 0;

        atEnd = false;
        PressSpace.SetActive(false);
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
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    break;
                case STANDING_TAG:
                    Debug.LogWarning("standing:" + tagValue + " - This tag is not needed for mother");
                    break;
                case CONFIDENCE_TAG:
                    Debug.LogWarning("confidence:" + tagValue + " - This tag is not needed for mother");
                    break;
                case DECAY_TAG:
                    Debug.LogWarning("decay:" + tagValue + " - This tag is not needed for mother");
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
