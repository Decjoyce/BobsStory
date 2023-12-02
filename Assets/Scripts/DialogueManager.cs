using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Slider timerBar;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    private bool dialoguePlaying;

    public Classmates classmate;

    [Header("Tag Handling")]
    [SerializeField] private TextMeshProUGUI displayNameText;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string TIME_TAG = "time";
    private const string STANDING_TAG = "standing";
    private const string END_TAG = "end";

    bool atEnd;

    public bool timerOn;
    float startTime;
    public float timeLeft;

    [SerializeField] Volume talkVolume, mainVolume;
    private Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);

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
            ContinueStory();

        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            timerBar.gameObject.SetActive(true);
            timerBar.value = timeLeft;
            vignette.intensity.value = ExtensionMethods.Map(timeLeft, 0, timerBar.maxValue, 1, 0);
        }
        else
        {
            timerBar.value = timerBar.maxValue;
        }

        if (timerOn && timeLeft <= 0)
            ContinueStory();
    }

    public void EnterDialogueMode(Classmates mate)
    {
        classmate = mate;
        currentStory = new Story(classmate.classmateType.inkJSONFile.text);
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);

        talkVolume.gameObject.SetActive(true);
        mainVolume.gameObject.SetActive(false);

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
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        classmate.ExitInteraction();
        classmate = null;

        timerOn = false;
        atEnd = false;

        vignette.intensity.value = 0;
        talkVolume.gameObject.SetActive(false);
        mainVolume.gameObject.SetActive(true);
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            timerOn = false;
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
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
                    Debug.Log("Yep");
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    break;
                case TIME_TAG:
                    timeLeft = float.Parse(tagValue);
                    timerBar.maxValue = timeLeft;
                    timerOn = true;
                    break;
                case STANDING_TAG:
                    classmate.classmateType.standing += int.Parse(tagValue);
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

}
